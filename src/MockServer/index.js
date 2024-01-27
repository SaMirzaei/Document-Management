const express = require('express');
const app = express();

app.get('/api', (req, res) => {
    const jsonData = [
        {
            name: "Product A", 
            type: 1, 
            baseCost: 5, 
            additionalKwhCost: 22
        },
        {
            name: "Product B",
            type: 2,
            baseCost: 800, 
            includedKwh: 4000,
            additionalKwhCost: 30
        }
    ];

    console.log('product types has been generated succussfully');

    res.json(jsonData);
});

const port = 3000;
app.listen(port, () => {
    console.log('Server is running on http://localhost:3000');
});
