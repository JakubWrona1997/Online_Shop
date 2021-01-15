var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        productModel: {
            name: "Nazwa produktu",
            description: "Opis",
            price: 10.99
        },
        products: []
    },
    methods: {
        getProducts() {
            this.loading = true;
            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        createProduct() {
            axios.post('/Admin/products', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        }
    },
    computed: {
        }
});