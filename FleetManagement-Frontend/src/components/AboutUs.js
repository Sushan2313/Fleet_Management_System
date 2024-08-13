import React from 'react';

function AboutUs() {
  return (
    <div className="container-fluid" style={{backgroundColor: '#f1f5f8',padding: '60px 20px' }}>
      <div className="row">
        <div className="col-md-12 ">
          <p style={{color: 'Blue',fontSize:'100px', fontWeight: 'bold',paddingTop:'30px'}}>Drive Drift</p>
          <h2 style={{color: 'black', fontWeight: 'bold',fontSize:'50px',paddingLeft:'800px',backgroundColor: '#bbd0c9'}}>Our Story</h2>
        </div>
      </div>
      
      <div className="row" style={{marginTop: '40px'}}>
        <div className="col-md-12">
          <p style={{color: 'black', fontWeight: 'bold', textAlign: 'center'}}>
            Welcome to Drive Drift! We are passionate about providing top-notch fleet management solutions tailored to meet the unique needs of our clients. Our mission is to empower businesses with innovative technology, ensuring smooth and efficient operations.
          </p>
        </div>
      </div>

      <div className="row" style={{marginTop: '40px'}}>
        <div className="col-md-12">
          <h3 style={{color: 'black', fontWeight: 'bold', textAlign: 'center'}}>Our History</h3>
          <p style={{color: 'black', textAlign: 'center'}}>
            Drive Drift was founded in 2015 Samruddhi Kadam, a visionary in the fleet management industry. With a background in logistics and technology, Samruddhi recognized the need for a more integrated and efficient solution for managing fleets. From humble beginnings, Drive Drift has grown into a leading provider of fleet management services, serving clients across the globe.
          </p>
        </div>
      </div>

      <div className="row" style={{marginTop: '40px'}}>
        <div className="col-md-6">
          <h3 style={{color: 'black', fontWeight: 'bold', textAlign: 'center'}}>Founder</h3>
          <p style={{color: 'black', textAlign: 'center'}}>
            <strong>Samruddhi Kadam</strong><br/>
            Samruddhi Kadam is the founder and visionary behind Drive Drift. With over 20 years of experience in the logistics and technology sectors, Samruddhi has been instrumental in driving innovation and excellence in fleet management.
          </p>
        </div>
        <div className="col-md-6">
          <h3 style={{color: 'black', fontWeight: 'bold', textAlign: 'center'}}>Director</h3>
          <p style={{color: 'black', textAlign: 'center'}}>
            <strong>Jane Smith</strong><br/>
            Jane Smith, the Director of Drive Drift, brings a wealth of experience in operations and management. Under her leadership, the company has achieved significant milestones and continues to set new standards in the industry.
          </p>
        </div>
      </div>

      <div className="row" style={{marginTop: '40px'}}>
        <div className="col-md-12">
          <h3 style={{color: 'black', fontWeight: 'bold', textAlign: 'center'}}>Our Vision and Mission</h3>
          <p style={{color: 'black', textAlign: 'center'}}>
            At Drive Drift, we believe in the power of collaboration and innovation. Our solutions are designed to adapt to the ever-changing landscape of the industry, ensuring that your business stays ahead of the curve. We are committed to continuous improvement and strive to exceed your expectations in everything we do.
          </p>
        </div>
      </div>

      <div className="row" style={{marginTop: '40px'}}>
        <div className="col-md-12 text-center">
          <h3 style={{color: 'black', fontWeight: 'bold'}}>Contact Us</h3>
          <p style={{color: 'black', textAlign: 'center'}}>
            <strong>Address:</strong> 123 Drive Drift Street, City, Country, ZIP Code<br/>
            <strong>Phone:</strong> +1-123-456-7890<br/>
            <strong>Email:</strong> contact@drivedrift.com
          </p>
        </div>
      </div>
    </div>
  );
}

export default AboutUs;
