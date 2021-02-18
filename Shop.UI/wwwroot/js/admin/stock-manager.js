var stockComponent = {
    data() {
        return {
            selectedProduct: null,
            newStock: {
                productId: 0,
                description: "Wielkość",
                quantity: 10
            },
            products: []
        }
    },
    mounted() {
        this.getStock();


    },
    methods: {
        getStock() {
            this.loading = true;
            axios.get('/Admin/stocks')
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
        selectProduct(product) {
            this.selectedProduct = product;
            this.newStock.productId = product.id;
        },
        updateStock() {

        },
        deleteStock() {

        },
        addStock() {
            this.loading = true;
            axios.post('/Admin/stocks', this.newStock)
                .then(res => {
                    console.log(res);
                    this.selectedProduct.stock.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
    }
}

Vue.component("stock-manager", (resolve, reject) => {
    axios.get("/js/templates/StockManager.html")
        .then(res => {
            stockComponent.template = res.data;
            resolve(stockComponent)
        })
        .catch(error => { reject(); })
});