const dbservice = require('../service/dbservice');
const bcrypt = require('bcryptjs');

async function registerUser(req, res) {
  const username = req.body.username;
  const password = req.body.password;

  if(!username || !password) {
    res.json({status: "Error", message: "Missing username or password!"});
    return;
  }

  try {
    if(await dbservice.doesUserExist(username) == false) {
      // Hash password
      let passwordHash = await bcrypt.hash(password, 10);
      try {
        await dbservice.createNewUser(username, passwordHash);
        res.json({message: "Registration successful!"});
        return;
      } catch(err) {
        res.status(500).json({message: "Error adding new user, please try again later."});
        console.log(err);
        return;
      }
    } else {
      res.json({message: "User already exists."});
      return;
    }
  } catch(err) {
    res.status(500).json({message: "Error connecting to database, please try again later."});
    console.log(err);
    return;
  }
}

module.exports = {registerUser}
