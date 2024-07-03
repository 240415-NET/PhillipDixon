import React from 'react'

interface ChildProps {
    guestbook: string[];
}
function ChildComponent({guestbook}:ChildProps){
        return(
            <div>
                <ul>
                    {guestbook.map((entry, index)=> (<li key={index}>{entry}</li>
                ))}
                </ul>
            </div>
        );
};

export default ChildComponent;