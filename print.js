const { exec } = require('child_process');
 
exec('python3.13 print.py', (error, stdout, stderr) => {
    console.log(stdout)
})