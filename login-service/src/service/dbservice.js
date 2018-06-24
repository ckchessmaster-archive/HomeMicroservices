const userModel = require('../model/userModel');

async function doesUserExist(username) {
  let result = await userModel.find({username: username}).exec();

  if(result.length == 0) {
    return false;
  } else {
    return true;
  }
}

async function createNewUser(username, password) {

}

module.exports = { doesUserExist, createNewUser}
