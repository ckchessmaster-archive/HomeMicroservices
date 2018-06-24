const UserModel = require('../model/userModel');
const mongoose = require('mongoose');

async function doesUserExist(username) {
  let result = await UserModel.find({username: username}).exec();

  if(result.length == 0) {
    return false;
  } else {
    return true;
  }
}

async function createNewUser(username, password) {
  let user = new UserModel({username: username, password: password});

  try{
    await user.save();
  } catch(err) {
    console.log(err);
  }
}

module.exports = { doesUserExist, createNewUser}
