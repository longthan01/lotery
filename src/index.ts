import sequelize from './sequelize'
import express from 'express'
const app = express();
sequelize
    .authenticate()
    .then(_ => console.log("Database connection established successfully")).catch(e => console.log("DB CONNECTION ERROR: " + e));

app.set("sequelize", sequelize);
app.listen(3000, () => {
    console.log("Server started on localhost:3000")
});