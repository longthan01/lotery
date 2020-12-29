import { Table, Column, Model, HasMany, IsUUID } from 'sequelize-typescript';

@Table({ tableName: "lottery" })
export default class Lotery extends Model<Lotery> {

    @Column
    @IsUUID(4)
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
