import React, {useState} from 'react';
import ChildComponent from './ChildComponent';

const ParentComponent = () => {
    const [guestbook, setGuestbook] = useState<any[]>([]);
    const [name, setName] = useState('');

    const handleSignGuestbook = () => {
        if (name.trim()) {
            const tempArray = guestbook;
            tempArray.push(name);
            setGuestbook(tempArray); 
            setName('');
        }
    };

    return(
        <div>
            <h2>Guestbook</h2>
            <input
                type="text"
                placeholder="Your name"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />
            <button onClick={handleSignGuestbook}>Give Jerkface your autograph</button>
            <ChildComponent guestbook={guestbook} />
        </div>
    );
};

export default ParentComponent