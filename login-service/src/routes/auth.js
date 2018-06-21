const dbservice = require('../service/dbservice');

function registerUser(req, res) {
  const username = req.body.username;
  const password = req.body.password;

  if(!isString(username) || !isString(password)) {
    res.json({message: "Invalid Credentials"});
    return;
  }

  if(await dbservice.doesUserExist(username) === false) {
    // Hash password
    let passwordHash = password;
    try {
      await dbservice.createNewUser(username, passwordHash);
      res.json({message: "Registration successful!"});
      return;
    } catch(err) {
      res.status(500).json({message: "Unable to add new user, please try again later."});
      return;
    }
  } else {
    res.json({message: "User already exists."});
    return;
  }
}

module.exports = {registerUser}
