import { useState, useEffect } from "react";

const DEFAULT_TECHNOLOGIES = [
    {id: 1, title: 'JSX и React', desc: 'Изучение работы JSX b React компонентов для контрольной работы', status: 'in-progress', category: 'Frontend', icon: '(-_-)', note: ''},
    {id: 2, title: 'SQL', desc: 'Изучение функций SQL к контрольной работе', status: 'completed', category: 'Backend', icon: '(-^-)', note: ''},
    {id: 3, title: 'C#', desc: 'Изучение базовых функций C# к контрольной работе', status: 'not-started', category: 'Backend', icon: '(>_<)', note: ''},
    {id: 4, title: 'Python', desc: 'Изучение языка Python для решения задач по ИИ и базам данных', status: 'in-progress', category: 'Data Science', icon: '<(-~-)>', note: ''}
];

export const useTechnologies = () => {
    const [technologies, setTechnologies] = useState(() => {
        const saved = localStorage.getItem('technologies');
        return saved ? JSON.parse(saved) : DEFAULT_TECHNOLOGIES;
    });

    useEffect(() => {
        localStorage.setItem('technologies', JSON.stringify(technologies));
    }, [technologies]);

    const updateStatus = (id) => {
        setTechnologies(prev => prev.map(t => {
            if (t.id ===  id) {
                const order = ['not-started', 'in-progress', 'completed'];
                const next = (order.indexOf(t.status) + 1) % 3;
                return {...t, status: order[next]};
            }
            return t;
        }));
    };

    const updateNote = (id, newNote) => {
        setTechnologies(prev =>prev.map(t => t.id === id ? {...t, note: newNote} : t));
    };

    const markAllCompleted = () => {
        setTechnologies(prev => prev.map(t => ({...t, status: 'completed'})));
    }

    const resetAll = () => {
        setTechnologies(prev => prev.map(t => ({...t, status: 'not-started'})));
    }

    const pickRandom = () => {
        const notCompleted = technologies.filter(t => t.status !== 'completed');
        if (notCompleted.length === 0) return;
        const random = notCompleted[Math.floor(Math.random() * notCompleted.length)];
        setTechnologies(prev => prev.map(t => t.id === random.id ? {...t, status: 'in-progress'}: t));
    };

    const exportData = () => {
        const dataStr = JSON.stringify(technologies, null, 2);
        const dataUri = 'data:application/json;charset=utf-8,' + encodeURIComponent(dataStr);
        const exportFileDefaultName = `technologies-export-${new Date().toISOString().slice(0, 10)}.json`;
        const linkElement = document.createElement('a');
        linkElement.setAttribute('href', dataUri);
        linkElement.setAttribute('download', exportFileDefaultName);
        linkElement.click();
    };

    return {
        technologies,
        updateStatus,
        updateNote,
        markAllCompleted,
        resetAll,
        pickRandom,
        exportData
    };
};