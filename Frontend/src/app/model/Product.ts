export class Product {
    id: number;
    name: string;
    price: number;
    photo: string;
    inventory: number;
    category: string;
    createdAt: string;


    constructor(
        id: number,
        name: string,
        price: number,
        photo: string,
        inventory: number,
        category: string,
        createdAt: string
    ) {
        this.id = id
        this.name = name
        this.price = price
        this.photo = photo
        this.inventory = inventory
        this.category = category
        this.createdAt = createdAt
    }

}