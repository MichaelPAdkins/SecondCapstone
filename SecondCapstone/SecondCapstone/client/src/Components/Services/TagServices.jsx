const baseURL = 'https://localhost:7013/api/tag';

export const getAllTags = () => {
    return fetch(`${baseURL}`)
        .then((res) => res.json());
};

export const addTag = (newTag) => {
    return fetch(`${baseURL}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newTag),
    });
};
export const getTagById = (id) => {
    return fetch(`${baseURL}/${id}`)
        .then((res) => res.json());
};

export const updateTag = (id, updatedTag) => {
    console.log("Updating tag with ID:", id);  // Log the ID being passed
    console.log("Tag Data:", updatedTag);  // Log the updated tag data

    return fetch(`${baseURL}/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedTag),
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update tag:', response);
        }
        return response;
    });
};


export const editTag = (tag) => {
    return fetch(`${baseURL}/${tag.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(tag),
    });
};

export const deleteTag = (tagId) => {
    return fetch(`${baseURL}/${tagId}`, {
        method: 'DELETE',
    });
};
