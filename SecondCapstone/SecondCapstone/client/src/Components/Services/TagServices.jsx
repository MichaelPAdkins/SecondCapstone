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
