export class ProductDTO {
    name: string;
    price: number;
    photo: string;
    inventory: number;
    category: string;

    constructor(
        name: string,
        price: number,
        photo: string,
        inventory: number,
        category: string
    ) {
        this.name = name
        this.price = price
        this.photo = photo
        this.inventory = inventory
        this.category = category
    }

}