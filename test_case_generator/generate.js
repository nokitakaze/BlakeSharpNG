#!/usr/bin/env node
'use strict';

const createBlakeHash = require("blake-hash");
const fs = require('fs');

/** BigNumber to hex string of specified length */
function toHex(number, length = 32) {
    if (!(number instanceof Buffer)) {
        throw new Error('Not a JS buffer');
    }

    const str = number.toString('hex');
    return '0x' + str.padStart(length * 2, '0');
}

let lines = [];

function generateHafaLine(i, j) {
    let ar = [];
    for (let n = 0; n < i; n++) {
        ar.push(0);
    }
    ar.push(j);

    const buf = new Buffer.from(ar);
    const blake256 = createBlakeHash("blake256").update(buf).digest('hex');
    const blake512 = createBlakeHash("blake512").update(buf).digest('hex');

    return `hafa\t${blake256}\t${blake512}\t${i}\t${j}`;
}

// Hafa
for (let i = 0; i < 100; i += 5) {
    for (let j = 0; j <= 255; j += 10) {
        lines.push(generateHafaLine(i, j));
    }
}

for (let i of [55 - 1, 72 - 1, 144 - 1]) {
    lines.push(generateHafaLine(i, 0));
}

for (let i = 102400; i <= 1024 * 1024; i += 102400) {
    for (let j = 0; j <= 255; j += 50) {
        lines.push(generateHafaLine(i, j));
    }
}

// Stairs
for (let i = 0; i < 254; i += 3) {
    for (let j = i + 1; j <= 255; j += 2) {
        let ar = [];
        for (let n = i; n <= j; n++) {
            ar.push(n);
        }

        const buf = new Buffer.from(ar);
        const blake256 = createBlakeHash("blake256").update(buf).digest('hex');
        const blake512 = createBlakeHash("blake512").update(buf).digest('hex');

        lines.push(`stairs\t${blake256}\t${blake512}\t${i}\t${j}`);
    }
}

// Save data
fs.writeFileSync('test-blake.tsv', lines.map(t => t + '\n').reduce((a, b) => a + b));
console.log('done');
