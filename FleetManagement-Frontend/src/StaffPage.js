import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

const StaffPage = () => {
  sessionStorage.setItem("staff", "true");
  const navigate = useNavigate();
  const [customerDetails, setCustomerDetails] = useState(null);

  const handleCancel = () => {
    const shouldCancel = window.confirm("Are you sure you want to cancel?");
    if (shouldCancel) {
      navigate("/CancelBookingByStaff");
    }
  };

  const handleEmailSubmit = (customer) => {
    setCustomerDetails(customer);
  };

  const handleBooking = () => {
    navigate("/BookingByStaff");
  };

  const handleReturn = () => {
    navigate("/Return");
  };

  const handleHandover = () => {
    navigate("/StaffHandOver");
  };

  return (
    <div 
      className="container-fluid text-center"  
      style={{ 
        minHeight: '100vh', 
        position: 'relative', 
        overflow: 'hidden',
        fontFamily: 'Arial, sans-serif', // Professional font
      }}
    >
      {/* Background Image */}
      <div 
        style={{ 
          position: 'absolute', 
          top: 0, 
          left: 0, 
          width: '100%', 
          height: '100%', 
          backgroundImage: `url('https://blog.hubspot.com/hubfs/GettyImages-1177482693.jpg')`, // Changed to a more professional image
          backgroundSize: 'cover', 
          backgroundPosition: 'center', 
          opacity: 0.6, // Slightly more transparent
          zIndex: -1 // Place the image behind the content
        }}
      />
      
      {/* Content */}
      <div 
        className="d-flex flex-column justify-content-start align-items-center" 
        style={{ 
          minHeight: '100vh', 
          position: 'relative', 
          zIndex: 1, 
          textAlign: 'center', 
          color: '#ffffff', // Light text color for better contrast
          paddingTop: '5%', // Space from the top
        }} 
        role="group" 
        aria-label="Staff Actions"
      >
        <h1 
          className="my-4" 
          style={{ 
            fontWeight: '700', 
            fontSize: '3rem', 
            color: '#000000', // Black color for the text
            marginBottom: '2rem' // Margin to separate from buttons
          }}
        >
          Staff Dashboard
        </h1><br></br><br>
        </br><br></br><br>
        </br>
        <div className="d-flex flex-column flex-md-row justify-content-center align-items-center">
          <button 
            className="btn btn-dark mb-2 mb-md-0 me-md-4" 
            style={{ 
              backgroundColor: 'rgba(0, 0, 0, 0.8)', // Darker faint black
              color: '#ffffff', 
              border: 'none', 
              borderRadius: '5px', 
              padding: '10px 20px', 
              fontSize: '1.2rem', 
              transition: 'background-color 0.3s ease', 
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.3)' // Added shadow for depth
            }} 
            onClick={handleBooking}
            onMouseEnter={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.9)'} // Hover effect
            onMouseLeave={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.8)'} // Hover effect
          >
            Booking
          </button>
          <button 
            className="btn btn-dark mb-2 mb-md-0 me-md-4" 
            style={{ 
              backgroundColor: 'rgba(0, 0, 0, 0.8)', 
              color: '#ffffff', 
              border: 'none', 
              borderRadius: '5px', 
              padding: '10px 20px', 
              fontSize: '1.2rem', 
              transition: 'background-color 0.3s ease', 
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.3)' 
            }} 
            onClick={handleHandover}
            onMouseEnter={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.9)'}
            onMouseLeave={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.8)'}
          >
            Handover
          </button>
          <button 
            className="btn btn-dark mb-2 mb-md-0 me-md-4" 
            style={{ 
              backgroundColor: 'rgba(0, 0, 0, 0.8)', 
              color: '#ffffff', 
              border: 'none', 
              borderRadius: '5px', 
              padding: '10px 20px', 
              fontSize: '1.2rem', 
              transition: 'background-color 0.3s ease', 
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.3)' 
            }} 
            onClick={handleReturn}
            onMouseEnter={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.9)'}
            onMouseLeave={(e) => e.target.style.backgroundColor = 'rgba(0, 0, 0, 0.8)'}
          >
            Return
          </button>
          <button 
            className="btn btn-danger mb-2 mb-md-0" 
            style={{ 
              backgroundColor: 'rgba(255, 0, 0, 0.8)', // Darker faint red
              color: '#ffffff', 
              border: 'none', 
              borderRadius: '5px', 
              padding: '10px 20px', 
              fontSize: '1.2rem', 
              transition: 'background-color 0.3s ease', 
              boxShadow: '0 4px 8px rgba(0, 0, 0, 0.3)' 
            }} 
            onClick={handleCancel}
            onMouseEnter={(e) => e.target.style.backgroundColor = 'rgba(255, 0, 0, 0.9)'}
            onMouseLeave={(e) => e.target.style.backgroundColor = 'rgba(255, 0, 0, 0.8)'}
          >
            Cancel
          </button>
        </div>
      </div>
    </div>
  );
};

export default StaffPage;
