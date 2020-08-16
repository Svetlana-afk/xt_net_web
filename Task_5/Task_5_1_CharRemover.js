var sentence = "У попа была собака, он её !!!";

function splitSentence(sentence) {
    sentence = sentence.split('!').join('');
    sentence = sentence.split('?').join('');
    sentence = sentence.split('.').join('');
    sentence = sentence.split('"').join('');
    return sentence.split(' ');
}

function findRepeatingChars(word, repeatingChars) {
    let str = word.toLowerCase();    
    for (var i = 0; i < word.length; i++) {
        if (str.lastIndexOf(str[i]) != i && !repeatingChars.includes(str[i])) {
            repeatingChars.push(str[i]);
        }
    }
    console.log(repeatingChars);
}
function charRemover(sentence) {
    let repeatingChars = [];
    let words = splitSentence(sentence);
    for (let i = 0; i < words.length; i++) {
        findRepeatingChars(words[i], repeatingChars);
    }
    for (let i = 0; i < repeatingChars.length; i++) {
        sentence = sentence.split(repeatingChars[i]).join('');
        sentence = sentence.split(repeatingChars[i].toUpperCase()).join('');
    }
    return sentence;
}

sentence = charRemover(sentence);
console.log(sentence);

