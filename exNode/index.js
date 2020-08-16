var a = "Sveta";
console.log(a);
console.log('avc' == a);


var words = [];
var repeatingChars = [];
var delimiterChars = ["!", "?", ":", ",", ".", " ", "\t", "\n"]
var sentence = "The young pope has dog Svetas, mems in evening!";
function splitSentence(sentence) {
   return sentence.split(' ');
}
words = splitSentence(sentence);
console.log("WORDS");
console.log(words);

function findRepeatingChars(word) {
    let str = word.toLowerCase();    
    for (var i = 0; i < word.length; i++) {
        if (str.lastIndexOf(str[i]) != i && !repeatingChars.includes(str[i]) && str[i]) {
            repeatingChars.push(str[i]);
            str = str.replace(str[i], '');
        }
    }
}
function charRemover(sentence, charsToRemove) {
    for (var i = 0; i < charsToRemove.length; i++) {
        sentence = sentence.split(charsToRemove[i]).join('');
    }
    return sentence;
}
for (var i = 0; i < words.length; i++) {
    findRepeatingChars(words[i]);
}
console.log("REPEATING_CHARS");
console.log(repeatingChars);
sentence = charRemover(sentence, repeatingChars);
console.log(sentence);

