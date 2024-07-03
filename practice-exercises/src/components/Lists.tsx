import React, { useState } from 'react';

function Lists() {
const [showList, setShowList] = useState(false);

const jerkfaceTraits:string[] = [
    'loud', 
    'obnoxious', 
    'annoying', 
    'persistent', 
    'cute'
];

return(
    <div>
        <button onClick={() => setShowList(!showList)}>View the top five traits that apply to Jerkface</button>{
            showList && (
                <ol>
                    {jerkfaceTraits.map((item, index) => (
                        <li key={index}>{item}</li>
                    ))}
                </ol>
            )}
    </div>
);
};

export default Lists;