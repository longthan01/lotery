import sequelize from './sequelize'
import express from 'express'
import { buildSchema } from 'type-graphql'
import { ApolloServer } from 'apollo-server-express';
import { LoteryResolver } from './graphql/resolvers/LoteryResolver';

const main = async () => {
    const app = express();
    sequelize
        .authenticate()
        .then(_ => console.log("Database connection established successfully")).catch(e => console.log("DB CONNECTION ERROR: " + e));

    app.set("sequelizeClient", sequelize);

    const apolloServer = new ApolloServer({
        schema: await buildSchema({
            resolvers: [LoteryResolver],
            validate: false,
        }),
        context: () => ({ sequelize })
    })

    apolloServer.applyMiddleware({ app });

    // start the server
    app.listen(3000, () => {
        console.log("Server started on localhost:3000")
    });
}

main();
