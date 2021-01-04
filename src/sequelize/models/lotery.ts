import { Table, Column, Model, IsUUID, PrimaryKey } from 'sequelize-typescript';
import { Field, ObjectType } from 'type-graphql';

@ObjectType()
@Table({ tableName: "lotteryinfo" })
export default class Lotery extends Model<Lotery> {

    @Field(() => String)
    @IsUUID(4)
    @PrimaryKey
    @Column
    id: string;

    @Field(() => String)
    @Column
    date: Date;

    @Field(() => String)
    @Column
    province: string;

    @Field()
    @Column
    number: string;

    @Field()
    @Column
    matchtype: string;
}
