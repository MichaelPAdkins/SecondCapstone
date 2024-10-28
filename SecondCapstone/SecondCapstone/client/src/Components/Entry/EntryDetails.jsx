import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { GetEntryById } from "../Services/EntryService.jsx";


export const EntryDetails = () => {
const {id} = useParams();
const [entry, setEntry] = useState({})
const navigate = useNavigate()

useEffect(() => {
    GetEntryById(id).then((entry) => setEntry(entry))
}, [])

    return (
        <>
        <li key={entry.id} className="entry-item">
        <p><strong>File Name:</strong> {entry.fileName}</p>
        <p><strong>Capture Date:</strong> {entry.captureDate}</p>
        <p><strong>Resolution:</strong> {entry.resolution}</p>
        <p><strong>File Size:</strong> {entry.fileSize}</p>
        <p><strong>Physical Backups:</strong> {entry.physicalBackUps}</p>

        {/* Display Camera */}
        {entry.camera && (
            <p><strong>Camera:</strong> {entry.camera.name}</p>
        )}

        {/* Display EntryLocations */}
        {entry.entryLocations && entry.entryLocations.length > 0 ? (
            <div>
                <p><strong>Locations:</strong></p>
                <ul>
                    {entry.entryLocations.map((location, index) => (
                        <li key={index}>{location.name}</li>
                    ))}
                </ul>
            </div>
        ) : (
            <p>No locations available</p>
        )}
        <button onClick={() => {navigate("/locations/create")}}> Add Location </button>

        {/* Display EntryTags */}
        {entry.entryTags && entry.entryTags.length > 0 ? (
            <div>
                <p><strong>Tags:</strong></p>
                <ul>
                    {entry.entryTags.map((tag, index) => (
                        <li key={index}>{tag.name}</li>
                    ))}
                </ul>
            </div>
        ) : (
            <p>No tags available</p>
        )}
        <button onClick={() => {navigate("/tags/create")}}> Add Tags </button>

    </li>

</>
)
}