const http = require("http");
const path = require("path");
const socketIo = require("socket.io");

const express = require("express");
const needle = require("needle");
const config = require("dotenv").config();

const TOKEN = process.env.TWITTER_BEARER_TOKEN;
const PORT = process.env.PORT || 3000;

const app = express();
const server = http.createServer(app);
const socket = socketIo(server, {
    cors: {
        origin: "http://localhost:4200",
        credentials: true,
        methods: ["GET", "POST"]
    }
});
// var cors = require('cors');

app.get('/', function(req, res) {
    res.setHeader('Access-Control-Allow-Origin', 'http:localhost:4200')
    res.set('Access-Control-Allow-Credentials', 'true')
});

const rulesURL = 'https://api.twitter.com/2/tweets/search/stream/rules';
const streamURL = 'https://api.twitter.com/2/tweets/search/stream?tweet.fields=created_at';

const rules = [
    { value: "recycling", tag: "recycling" }
]

async function getRules() {
    const response = await needle('get', rulesURL, {
        headers: {
            Authorization: `Bearer ${TOKEN}`
        }
    })
    return response.body;
}

async function setRules() {
    const data = {
        add: rules
    };

    const response = await needle('post', rulesURL, data, {
        headers: {
            'content-type': 'application/json',
            Authorization: `Bearer ${TOKEN}`
        }
    });

    return response.body;
}

async function deleteRules(rules) {
    if (!Array.isArray(rules.data)) {
        return null;
    }

    const ids = rules.data.map((rule) => rule.id);
    const data = {
        delete: {
            ids: ids
        }
    };

    const response = await needle('post', rulesURL, data, {
        headers: {
            'content-type': 'application/json',
            Authorization: `Bearer ${TOKEN}`
        }
    })

    return response.body;
}

function streamTweets(socket) {
    const stream = needle.get(streamURL, {
        headers: {
            Authorization: `Bearer ${TOKEN}`
        }
    });
    stream.on('data', (data) => {
        try {
            const json = JSON.parse(data);
            socket.emit('tweet', json);
            console.log(json);
        } catch (error) {

        }
    })
}

socket.on('connection', async() => {
    console.log('Client connected on twitter server')
    let currentRules;
    try {
        currentRules = await getRules();
        await deleteRules(currentRules);

        await setRules();
        currentRules = await getRules();
    } catch (error) {
        console.log(error);
        process.exit(1);
    }
    streamTweets(socket);
})

server.listen(PORT, () => console.log(`Listening on port ${PORT}`));