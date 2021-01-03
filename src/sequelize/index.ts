import { Sequelize } from 'sequelize-typescript';
const sequelize = new Sequelize({
    database: 'lotery',
    dialect: 'postgres',
    username: 'sm',
    password: '',
    models: [__dirname + '/models'],
});
export default sequelize;