import './App.css';
import Greeting from './Greeting';
import UserCard from './UserCard';
import TechnologyCard from './TechnologyCard';
import Photo_profile from './assets/photo_profile.jpg';
import { useState } from "react";
import Statistics from './Statistics';
import QuickActions from './QuickActions';
import FilterTabs from './FilterTabs';
import { useTechnologies } from './useTechnologies';

function App() {

  const {
    technologies,
    updateStatus,
    updateNote,
    markAllCompleted,
    resetAll,
    pickRandom,
    exportData
  } = useTechnologies();

  const [filter, setFilter] = useState('all');
  const [ searchQuery, setSearchQuery ] = useState('');

  const filteredTechs = technologies
  .filter(t => filter === 'all' || t.status === filter)
  .filter(t => 
    t.title.toLowerCase().includes(searchQuery.toLowerCase()) ||
    t.desc.toLowerCase().includes(searchQuery.toLowerCase())
  );

  const resultCount = filteredTechs.length;

  return (
    <div className='App'>
      <Greeting />
      <UserCard 
        name="Оля Гузаирова"
        role="Глав админ или просто чел"
        avatarUrl={Photo_profile}
        isOnline={true} 
      />
      <header className="App-header">
        <h1>Что-то на потом, возможно</h1>
        <Statistics technologies={technologies} />
      </header>

      <div className='search-bar'>
        <input
          type='text'
          placeholder='Поиск по названию или описанию'
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          className='search-input'
        />
        <span className='result-search'>
          Найдено: {resultCount} {resultCount === 1 ? 'технология' : 'технологии(й)'}
        </span>
      </div>

      <QuickActions 
        onMarkAll={markAllCompleted}
        onReset={resetAll}
        onRandom={pickRandom} 
        onExport={exportData}
      />

      <FilterTabs currentFilter={filter} onFilterChange={setFilter} />

      <main className="tech-grid">
        {filteredTechs.length === 0 ? (
          <p className="empty-message">
            Ничего не найдено по фильтру "{filter}"
          </p>
        ) : (
          filteredTechs.map(tech => (
            <TechnologyCard 
              key={tech.id} 
              tech={tech} 
              onStatusChange={updateStatus}
              onNoteChange={updateNote}
            />
          ))
        )}
      </main>
    </div>
  );
}

export default App;
