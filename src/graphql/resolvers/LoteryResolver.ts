import Lotery from "../../sequelize/models/lotery";
import { Ctx, Query, Resolver } from "type-graphql";
import { GraphqlContext } from "../GraphqlContext";

@Resolver()
export class LoteryResolver {
    @Query(() => [Lotery])
    lotery(@Ctx() ctx: GraphqlContext) {
        return ctx.sequelize.models.Lotery.findAll({
            limit: 50,
        })
    }
}