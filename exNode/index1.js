var sentence = "The young pope has dog Svetas, mems in evening!";
function splitSentence(sentence) {
   return sentence.split(' ');
}

function findRepeatingChars(word, repeatingChars) {
    let str = word.toLowerCase();    
    for (var i = 0; i < word.length; i++) {
        if (str.lastIndexOf(str[i]) != i && !repeatingChars.includes(str[i]) && str[i]) {
            repeatingChars.push(str[i]);
            str = str.replace(str[i], '');
        }
    }
}
function charRemover(sentence) {
    let repeatingChars = [];
    let words = splitSentence(sentence);
    for (var i = 0; i < words.length; i++) {
        findRepeatingChars(words[i], repeatingChars);
    }
    for (var i = 0; i < repeatingChars.length; i++) {
        sentence = sentence.split(repeatingChars[i]).join('');
        sentence = sentence.split(repeatingChars[i].toUpperCase()).join('');
    }
    return sentence;
}

sentence = charRemover(sentence);
console.log(sentence);

