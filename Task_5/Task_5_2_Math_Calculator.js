var expression = "3.5 + 4* 10-5.3/5=";
//var reg = /[-+]?[0-9]*[.,]?[0-9]+/;

function calculator(expression) {
    let currentValue = 0;
    let regForNumber = /[0-9]*[.,]?[0-9]+/g;
    expression = expression.split(' ').join('');
    let numStr = expression.match(regForNumber);        
    mathOperations = expression.replace(regForNumber, '');
    currentValue = Number(numStr[0]);   
    for (var i = 0; i < mathOperations.length; i++) {
        switch (mathOperations[i]) {
            case '+':
                currentValue = currentValue + Number(numStr[i + 1]);
                break;
            case '-':
                currentValue = currentValue - Number(numStr[i + 1]);
                break;
            case '*':
                currentValue = currentValue * Number(numStr[i + 1]);
                break;
            case '/':
                currentValue = currentValue / Number(numStr[i + 1]);
                break;
            case '=':
                console.log(currentValue.toFixed(2));
                break;
            default: console.log("Bad bad expression");
        }
    }
}
calculator(expression);