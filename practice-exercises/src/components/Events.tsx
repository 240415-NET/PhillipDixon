import React, { useState } from 'react';

function Events() {
    const [showParagraph, setShowParagraph] = useState(false);
    function hideParagraph() {setShowParagraph(false);}
    
    function HandleButtonClick() {
        setShowParagraph(true);
        setTimeout(() => {hideParagraph();},10000);
    }
        return (
            <div>
                <button onClick={HandleButtonClick}>I saw Jerkface!</button>
                <br />
                {showParagraph && (
                    <p>At least you can't hear him!</p>
                )}
            </div>
        );
    }


export default Events;