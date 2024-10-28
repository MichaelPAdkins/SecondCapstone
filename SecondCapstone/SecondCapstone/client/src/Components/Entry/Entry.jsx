import { Link, useNavigate } from "react-router-dom"

export const Entry = ({entry}) => {
const navigate = useNavigate()


return (
    <>
                        <li key={entry.id} className="entry-item">
                        <Link to={`/entries/${entry.id}`}><strong>File Name:</strong> {entry.fileName}</Link>
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