const mongoose = require('mongoose');

let userSchema = mongoose.Schema({
  username: String,
  password: String
});

module.exports = mongoose.model('User', userSchema);
