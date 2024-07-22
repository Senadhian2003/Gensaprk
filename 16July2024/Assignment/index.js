const vocabulary = ['mango', 'river', 'cloud', 'happy', 'zebra', 'ocean', 'lemon', 'piano', 'tiger', 'dream'];
let targetWord = vocabulary[Math.floor(Math.random() * vocabulary.length)];
let maxGuesses = 5;
let currentGuess = 0;
let letterIndex = 0;

const wordGrid = document.getElementById('word-grid');
const inputPanel = document.getElementById('input-panel');
const feedback = document.getElementById('feedback');

function initializeWordGrid() {
    for (let i = 0; i < maxGuesses; i++) {
        for (let j = 0; j < 5; j++) {
            const cell = document.createElement('div');
            cell.classList.add('cell');
            wordGrid.appendChild(cell);
        }
    }
}

function createInputPanel() {
    const rows = [
        ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
        ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L'],
        ['GO', 'Z', 'X', 'C', 'V', 'B', 'N', 'M', '←']
    ];

    rows.forEach(row => {
        const rowElement = document.createElement('div');
        rowElement.classList.add('input-row');
        row.forEach(key => {
            const buttonElement = document.createElement('button');
            buttonElement.classList.add('input-button');
            buttonElement.textContent = key;
            buttonElement.setAttribute('data-key', key);
            if (key === 'GO') buttonElement.id = 'submit-button';
            if (key === '←') buttonElement.id = 'delete-button';
            buttonElement.addEventListener('click', () => handleInput(key));
            rowElement.appendChild(buttonElement);
        });
        inputPanel.appendChild(rowElement);
    });
}

function handleInput(key) {
    if (currentGuess >= maxGuesses) return;
    if (key === 'GO') {
        checkGuess();
    } else if (key === '←') {
        removeLetter();
    } else if (letterIndex < (currentGuess + 1) * 5) {
        insertLetter(key);
    }
}

function insertLetter(letter) {
    if (letterIndex < (currentGuess + 1) * 5) {
        const cell = wordGrid.children[letterIndex];
        cell.textContent = letter;
        letterIndex++;
    }
}

function removeLetter() {
    if (letterIndex > currentGuess * 5) {
        letterIndex--;
        const cell = wordGrid.children[letterIndex];
        cell.textContent = '';
    }
}

function checkGuess() {
    if (letterIndex % 5 !== 0 || letterIndex !== (currentGuess + 1) * 5) {
        feedback.textContent = 'Your word must be 5 letters long.';
        return;
    }

    const guessedWord = Array.from(wordGrid.children)
        .slice(currentGuess * 5, (currentGuess + 1) * 5)
        .map(cell => cell.textContent.toLowerCase())
        .join('');

    let remainingTarget = targetWord;

    for (let i = 0; i < 5; i++) {
        const cell = wordGrid.children[currentGuess * 5 + i];
        const letter = guessedWord[i];
        const button = document.querySelector('.input-button:not(#submit-button):not(#delete-button)[data-key="${letter.toUpperCase()}"]');

        if (letter === targetWord[i]) {
            cell.classList.add('exact');
            button.classList.add('exact');
            remainingTarget = remainingTarget.replace(letter, '_');
        }
    }

    for (let i = 0; i < 5; i++) {
        const cell = wordGrid.children[currentGuess * 5 + i];
        const letter = guessedWord[i];
        const button = document.querySelector('.input-button:not(#submit-button):not(#delete-button)[data-key="${letter.toUpperCase()}"]');

        if (letter === targetWord[i]) {
            // Already handled
        } else if (remainingTarget.includes(letter)) {
            cell.classList.add('misplaced');
            if (!button.classList.contains('exact')) {
                button.classList.add('misplaced');
            }
            remainingTarget = remainingTarget.replace(letter, '_');
        } else {
            cell.classList.add('incorrect');
            button.classList.add('incorrect');
        }
    }

    if (guessedWord === targetWord) {
        feedback.textContent = 'Excellent! You\'ve guessed the word!';
        deactivateInputPanel();
    } else {
        currentGuess++;
        if (currentGuess >= maxGuesses) {
            feedback.textContent = `Game over. The word was ${targetWord}.`;
            deactivateInputPanel();
        }
    }
    letterIndex = currentGuess * 5;
}

function deactivateInputPanel() {
    const buttons = document.querySelectorAll('.input-button');
    buttons.forEach(button => button.disabled = true);
}

initializeWordGrid();
createInputPanel();

document.addEventListener('keydown', (event) => {
    const key = event.key.toUpperCase();
    if (key === 'ENTER' || key === 'BACKSPACE' || (key.length === 1 && key.match(/[A-Z]/))) {
        handleInput(key === 'ENTER' ? 'GO' : (key === 'BACKSPACE' ? '←' : key));
    }
});