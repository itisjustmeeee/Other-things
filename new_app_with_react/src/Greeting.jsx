function Greeting() {
    const userName = "Olay";
    const currentHour = new Date().getHours();

    let timeOfDay;
    if (6 < currentHour) {
        timeOfDay = 'Good morning';
    }
    else if (12 < currentHour) {
        timeOfDay = 'Good day';
    }
    else {
        timeOfDay = 'Good night';
    }
    return (
        <div className="greeting">
            <h1>{timeOfDay}, {userName}</h1>
            <p>Рада видеть вас в приложении</p>
        </div>
    );
}

export default Greeting;