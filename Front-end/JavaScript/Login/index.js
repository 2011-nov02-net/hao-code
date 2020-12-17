'use strict';

document.addEventListener('DOMContentLoaded', () =>
{
    const loginForm = document.getElementById('loginForm');
    
    loginForm.addEventListener('submit', (event)=>
    {       
        event.preventDefault();
        //const name = document.getElementById('name').value;
        //const email = document.getElementById('email').value;
        if( loginForm.name.value === 'Hao' && loginForm.email.value === 'Hao@gmail.com' )
        {           
            // redirect           
            window.location.replace('Welcome.html');
        }
        else
        {
            // error message
            alert("username and email do not match!");
        }
    })
});


// single page login -> welcome, welcome <- logout


