conn = new Mongo();
db = conn.getDB("Basket");
db.Stock.createIndex({"ProductComponentId": 1}, {unique: true});
db.Stock.insert({
    "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0UQ=="),
    "Quantity": 100
});
db.Stock.insert({
    "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0Ug=="),
    "Quantity": 100
});
db.Stock.insert({
    "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0Uw=="),
    "Quantity": 100
});
db.Stock.insert({
    "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0VA=="),
    "Quantity": 100
});

db.Catalog.createIndex({"ProductCompositeId": 1}, {unique: true});

db.Catalog.insert({
    "ProductComponents": [
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0UQ=="),
                "Name": "Kırmızı Büyük Boy Kalp Kurabiye",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 10
        },
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0Ug=="),
                "Name": "Kırmızı Büyük Boy Kalp Cikolata",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 10
        }
    ],
    "ProductCompositeId": BinData(3, "ZF+oPxdXYkWz/CyWP2avpA=="),
    "Name": "Kişiye Özel Tutkulu Düşler Kek Buketi",
    "Price": 100
});
db.Catalog.insert({
    "ProductComponents": [
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0Uw=="),
                "Name": "Kırmızı Büyük Boy Kalp Kurabiye",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 10
        },
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0VA=="),
                "Name": "Kırmızı Büyük Boy Kalp Cikolata",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 10
        }
    ],
    "ProductCompositeId": BinData(3, "ZF+oPxdXYkWz/CyWP2avpg=="),
    "Name": "Mutluluk Masalı Lilyum ve Kırmızı Gül Aranjmanı",
    "Price": 99
});
db.Catalog.insert({
    "ProductComponents": [
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0Uw=="),
                "Name": "Kırmızı Büyük Boy Kalp Kurabiye",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 150
        },
        {
            "Component": {
                "ProductComponentId": BinData(3, "C09mOb77AkWqBRbz7we0VA=="),
                "Name": "Kırmızı Büyük Boy Kalp Cikolata",
                "ProductComponentSpecification": {
                    "_id": 2,
                    "Name": "BonnyFood"
                }
            },
            "Quantity": 150
        }
    ],
    "ProductCompositeId": BinData(3, "ZF+oPxdXYkWz/CyWP2avpQ=="),
    "Name": "Mutluluk Masalı Lilyum ve Kırmızı Gül Aranjmanı Aile Boyu",
    "Price": 100000
});
