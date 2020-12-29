import { Sequelize } from 'sequelize-typescript';
const sequelize = new Sequelize({
    database: 'lotery',
    dialect: 'postgres',
    username: 'sm',
    password: '',
    models: [__dirname + '/src/sequelize/models'],
});
export default (app: { Sequelize: Sequelize; }) => {
    app.Sequelize = sequelize;
}