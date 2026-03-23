require('dotenv').config()
const express = require("express")
const router = require('./routes')
const dbHandler = require('./dbHandler')

const server = express()
const port = process.env.PORT

server.use(express.json())
server.use(express.static('public'))
server.use(router)

server.listen(port, () => console.log("A szerver fut a következő porton"+ port))