import React from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import '@fortawesome/fontawesome-free/css/all.css';
import { Link } from 'react-router-dom';

function Footer() {
  const sectionStyle = {
    background: `url('https://t4.ftcdn.net/jpg/05/00/76/75/360_F_500767502_AdezwSUsyb04l79RpV6zubKulRnIHpd0.jpg') no-repeat center center fixed`,
    backgroundSize: 'cover',
    height: '150px',
    backgroundColor: '#405D72',
    width: '100%',
    position: 'relative',
    padding: '10px 0', // Add padding for spacing
  };

  const footerContainerStyle = {
    height: '100%',
    display: 'flex',
    flexDirection: 'column', // Stack items vertically
    justifyContent: 'space-between', // Space out items
    padding: '0 20px', // Add padding for better spacing
  };

  const socialLinksStyle = {
    display: 'flex',
    gap: '15px',
    marginBottom: '10px',
    marginTop: '15px',
  };

  const usefulLinksContainerStyle = {
    display: 'flex',
    flexDirection: 'row',
    flexWrap: 'wrap',
    gap: '10px',
    position: 'absolute',
    bottom: '65px',
    right: '25px',
  };

  const linkStyle = {
    textDecoration: 'none',
    color: 'white',
  };

  return (
    <footer style={sectionStyle} className="text-light mt-auto">
      <Container style={footerContainerStyle}>
        <Row className="w-100">
          <Col md={12} className="d-flex justify-content-start align-items-center">
            <div className="d-flex flex-column">
              <p>&copy; {new Date().getFullYear()} Drive Drift. All rights reserved.</p>
              <div style={socialLinksStyle}>
                <a href="mailto:example@gmail.com" className="text-light" target="_blank" rel="noopener noreferrer" style={linkStyle}>
                  <i className="fa fa-envelope fa-lg" style={{ marginRight: '8px' }}></i>
                  Email
                </a>
                <a href="https://www.instagram.com/" className="text-light" target="_blank" rel="noopener noreferrer" style={linkStyle}>
                  <i className="fa-brands fa-instagram fa-lg" style={{ marginRight: '8px' }}></i>
                  Instagram
                </a>
                <a href="https://www.facebook.com/" className="text-light" target="_blank" rel="noopener noreferrer" style={linkStyle}>
                  <i className="fa-brands fa-facebook fa-lg" style={{ marginRight: '8px' }}></i>
                  Facebook
                </a>
                <a href="https://twitter.com/" className="text-light" target="_blank" rel="noopener noreferrer" style={linkStyle}>
                  <i className="fa-brands fa-twitter fa-lg" style={{ marginRight: '8px' }}></i>
                  Twitter
                </a>
              </div>
            </div>
          </Col>
          <Col md={12} className="d-flex justify-content-end">
            <div style={usefulLinksContainerStyle}>
              <Link to="/aboutus" style={linkStyle}>About Us</Link>
              <Link to="/AffiliatedHotels" style={linkStyle}>Affiliated Hotels</Link>
              <Link to="/WeatherRedirect" style={linkStyle}>Weather</Link>
              <Link to="/CustomerCare" style={linkStyle}>Contact Us</Link>
              <Link to="/sitemap" style={linkStyle}>SiteMap</Link>
              <Link to="/CareerPage" style={linkStyle}>Careers</Link>
            </div>
          </Col>
        </Row>
      </Container>
    </footer>
  );
}

export default Footer;