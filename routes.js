const express = require('express')
const router = express.Router()

const snails = ['kis csiga','nagy csiga','csiga3']

router.get("/csigak", (req,res) =>{
    res.status(200).json({snails:snails}).end()
})
router.post("/csiga", (req,res)=> {
    const { snail } = req.body
    snails.push(snail)
    res.status(201).json({message:"sikeres létrehozás"})
})
router.delete("/csiga", (req,res)=> {
    snail.pop()
    res.status(200).json({message: "sikeres törlés"}).end()
})

module.exports = router