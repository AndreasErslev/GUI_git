const url = "https://localhost:5001/";

const makeHeader = () => {
    const header = {
        "Content-Type": "application/json",
    };
    const jwt = localStorage.getItem("jwt");
    if (jwt !== null) {
        header.Authorization = "Bearer " + jwt;
    }
    return header;
};

export const post = (endpoint, data) => {
    return fetch(url + endpoint, {
        method: "POST",
        credentials: "include",
        withCredentials: true,
        headers: makeHeader(),
        body: JSON.stringify(data),
    });
};

export const get = endpoint =>
    fetch(url + endpoint, {
        method: "GET",
        credentials: "include",
        withCredentials: true,
        headers: makeHeader(),
    });

export const del = endpoint =>
    fetch(url + endpoint, {
        method: "DELETE",
        credentials: "include",
        withCredentials: true,
        headers: makeHeader(),
    });

export const put = endpoint =>
    fetch(url + endpoint, {
        method: "PUT",
        credentials: "include",
        withCredentials: true,
        headers: makeHeader(),
    });
