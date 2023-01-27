
		// Hamburger BTN 
        const toggleBtn = document.querySelector('.toggleBtn');
		const sidebar = document.querySelector('.sidebar');
		// add eventlistener for click
		toggleBtn.addEventListener('click', () => {
			//toggle active to add styling to class
			toggleBtn.classList.toggle('active');
			sidebar.classList.toggle('active');
		});
        
	
