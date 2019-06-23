const axios = require("axios");

const baseUrl = 'http://localhost:8080/api/';

function get(url) {
    return axios.get(baseUrl + url, {
        headers: {
            Authorization: "Bearer " + localStorage.getItem("token")
        }
    })
};

function post(url, data) {
    return axios.post(baseUrl + url, data,
        {
            headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
            }
        }
    );
};

module.exports = {
    get: get,
    post: post
};
