import { join } from 'path'
import { readFileSync } from 'fs'

const input = readFileSync(join(__dirname, './data.txt'), 'utf-8')

function anyDuplicates(arr: string[]) {
    return arr.some((item) => arr.indexOf(item) !== arr.lastIndexOf(item))
}

function part1() {
    const chars = input.split('')
    const current4Characters: string[] = [chars[0], chars[1], chars[2], chars[3]]
    
    if (!anyDuplicates(current4Characters)) {
        return 4 // no duplicates in first 4 so just return 4
    }

    let answer: number | undefined = undefined
    for (let [index, char] of chars.slice(4).entries()) {
        current4Characters.shift()
        current4Characters.push(char)

        if (!anyDuplicates(current4Characters)) {
            answer = index + 5 // index starts at 0 so add 1 for normalising the output
            break
        }
    }

    return answer
}

function part2() {
    const chars = input.split('')
    const numberOfCharactersUntilMessage = 14
    const currentXCharacters: string[] = []
    for(let i = 0; i < numberOfCharactersUntilMessage; i++) {
        currentXCharacters.push(chars[i])
    }
    
    if (!anyDuplicates(currentXCharacters)) {
        return numberOfCharactersUntilMessage
    }

    let answer: number | undefined = undefined
    for (let [index, char] of chars.slice(numberOfCharactersUntilMessage).entries()) {
        currentXCharacters.shift()
        currentXCharacters.push(char)

        if (!anyDuplicates(currentXCharacters)) {
            answer = index + numberOfCharactersUntilMessage + 1 // index starts at 0 so add 1 for normalising the output
            break
        }
    }

    return answer
}

console.log(`part 1 ${part1()}`)
console.log(`part 2 ${part2()}`)
