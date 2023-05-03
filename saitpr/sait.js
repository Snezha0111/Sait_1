async function getAllGoods(){
    var result = await fetch("https://localhost:7010/api/Infoproduct");
    console.log(result);
    if(result.status!== 200)  {
        console.log('Ошибка: '+ result.status);
        return;
    }

    var data = await result.json();
    for (let i = 0; i<data.length; i++) {
        console.log(data[i]);
        addGoodCard(data[i]);
    }
}

getAllGoods();

function addGoodCard(good){
    let list = document.getElementById('goods-list')
    let card = document.createElement('div');
    card.className = "card";
    card.innerHTML = 
    '<img src="'+ good.url +'"alt="Denim Jeans" style="width:100%">'+
    '<h1>' + good.name + '</h1>' +
    '<p class = "price">' + good.price + '</p>' +
    '<p>'+ good.description + '</p>' +
    '<p><button>Add to Cart</button></p>';
    list.appendChild(card);
}

