const app = require('./index');
const express = require('express');
const authRoutes = require('./src/routes/auth.js');
const router = express.Router();

router.get('/', (req, res) => res.send('Hello Worldz!'));
router.post('/registerUser', authRoutes.registerUser);
//router.post('/login', app.oauth.grant());

module.exports = router;
