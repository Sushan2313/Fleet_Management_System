import React, { useState } from "react";

export default function LoginComponent() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [passwordError, setPasswordError] = useState('');

  const handleLogin = () => { 
    const url = `http://localhost:8080/login/${encodeURIComponent(email)}/${encodeURIComponent(password)}`;

    fetch(url)
      .then(response => response.json())
      .then(data => {
        if (data) {
          sessionStorage.setItem('isLoggedIn', true);
          fetchCustomerData(email);

          if (sessionStorage.getItem('continuekaro') === 'true') {
            window.location.href = '/ConfirmBooking';
          } else {
            window.location.href = '/BookingForm';
          }
        } else {
          alert('Login  failed');
        }
      })
      .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while logging in. Please try again later.');
      });
  };
  // const handleLogin = () => {
  //   const url = 'http://localhost:8080/public/token';
  //   const credentials = {
  //     username: 'mayur',
  //     password: 'mayur'
  //   };
  
  //   // Fetch token
  //   fetch(url, {
  //     method: 'POST',
  //     headers: {
  //       'Content-Type': 'application/json'
  //     },
  //     body: JSON.stringify(credentials)
  //   })
  //   .then(response => {
  //     if (!response.ok) {
  //       throw new Error('Network response was not ok');
  //     }
  //     // console.log(response.json())
  //     return response.json();
  //   })
  //   .then(tokenData => {
  //     const { token } = tokenData;
  //     const loginUrl = http://localhost:8080/login/${encodeURIComponent(email)}/${encodeURIComponent(password)};
  
  //     // Fetch login
  //     fetch(loginUrl, {
  //       headers: {
  //         Authorization: Bearer ${token}
  //       }
  //     })
  //     .then(response => {
  //       if (!response.ok) {
  //         throw new Error('Login failed');
  //       }
  //       return response.json();
  //     })
  //     .then(data => {
  //       if (data) {
  //         sessionStorage.setItem('isLoggedIn', true);
  //         fetchCustomerData(email);
  //         alert('Login successful');
  //         if (sessionStorage.getItem('continuekaro') === 'true') {
  //                     window.location.href = '/ConfirmBooking';
  //                   } else {
  //                     window.location.href = '/BookingForm';
  //                   }
  //       } else {
  //         alert('Login failed');
  //       }
  //     })
  //     .catch(error => {
  //       console.error('Error:', error);
  //       alert('An error occurred while logging in. Please try again later.');
  //     });
  //   })
  //   .catch(error => {
  //     console.error('Error:', error);
  //     alert('An error occurred while logging in. Please try again later.');
  //   });
  // };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (password.length < 2) {
      setPasswordError('Password must be at least 8 characters long');
      return;
    }
    setPasswordError('');
    handleLogin();
  };
  const handleSubmit1 = (event) => {
    window.location.href = '/CustomerForm';
  };
  
  const fetchCustomerData = (email) => {
    const url = `http://localhost:8080/customer/${encodeURIComponent(email)}`;

    fetch(url)
      .then(response => response.json())
      .then(customerData => {
        // Store customer data in session storage
        sessionStorage.setItem('customerData', JSON.stringify(customerData));
      })
      .catch(error => {
        console.error('Error:', error);
        alert('An error occurred while fetching customer data.');
      });
  };
  return (
    <div
      className="container-fluid d-flex justify-content-center align-items-center"
      style={{
        minHeight: "100vh",
        background: `url('https://wallpapercave.com/wp/wp7969229.jpg') no-repeat center center fixed`,
        backgroundSize: 'cover',
      }}
    >
      <div className="row" style={{ width: '80%', height: '80%' }}>
        <div className="col-md-6" style={{ padding: 0 }}>
          <img
            src="https://images.pexels.com/photos/1181244/pexels-photo-1181244.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2"
           

            alt="Login Side Image"
            style={{ width: '100%', height: '100%', objectFit: 'cover' }}
          />
        </div>
        <div className="col-md-6 d-flex align-items-center" style={{ padding: '20px', backgroundColor: 'rgba(255, 255, 255, 0.8)' }}>
          <div className="card" style={{ width: '100%' }}>
            <div className="card-body" style={{ backgroundColor: "steelblue", opacity: "0.9" }}>
              <h2 className="card-title text-center">Login</h2>
              <form onSubmit={handleSubmit}>
                <div className="form-group">
                  <label htmlFor="email">Email:</label>
                  <input
                    type="email"
                    className="form-control"
                    id="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="password">Password:</label>
                  <input
                    type="password"
                    className="form-control"
                    id="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                  />
                  {passwordError && <div className="invalid-feedback">{passwordError}</div>}
                </div>
                <div className="text-center">
                  <button type="submit" className="btn btn-primary" style={{ marginRight: '10px' }}>Log in</button>
                  <button type="button" className="btn btn-secondary" onClick={handleSubmit1}>Register</button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}