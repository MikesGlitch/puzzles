import path from 'path'
import fs from 'fs'
const input = fs.readFileSync(path.join(__dirname, './data.txt'), 'utf-8')
interface Elf {
  items: number[];
  totalCals: number
}

const list = input.split('\r\n');
const elfs: Elf[] = [];
let currentElf: Elf | undefined = undefined
list.map((item) => {
  if (item === '') {
    if (currentElf) {
      currentElf.totalCals = currentElf.items.reduce((prev, cur) => prev + cur, 0) // total
      elfs.push(currentElf)
    }

    currentElf = { items: [], totalCals: 0 } // init
  } else {
    currentElf?.items.push(Number(item))
  }
});

const elfsTotalCals = elfs.map((elf) => elf.totalCals)


const sorted = elfsTotalCals.sort((a, b) => { return b - a })
const top3 = sorted.slice(0, 3)
console.log('part 1', sorted[0])
console.log('part 2', top3.reduce((prev, cur) => prev + cur, 0))