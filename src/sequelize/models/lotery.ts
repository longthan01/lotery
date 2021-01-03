import { Table, Column, Model, IsUUID, PrimaryKey } from 'sequelize-typescript';

@Table({ tableName: "lotteryinfo" })
export default class Lotery extends Model<Lotery> {

    @IsUUID(4)
    @PrimaryKey
    @Column
    id: string;

    @Column
    date: Date;

    @Column
    province: string;

    @Column
    number: string;

    @Column
    matchtype: string;
}
