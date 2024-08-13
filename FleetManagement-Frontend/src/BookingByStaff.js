import React, { useState } from 'react';
import { Form, Button, Container, Row, Col } from 'react-bootstrap';

const BookingByStaff = ({ onEmailSubmit }) => {
  const [email, setEmail] = useState('');
  const [customerData, setCustomerData] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setLoading(true);
    try {
      const response = await fetch(`http://localhost:8080/customer/${email}`);
      if (response.ok) {
        const data = await response.json();
        setCustomerData(data);
        sessionStorage.setItem('customerData', JSON.stringify(data));
        onEmailSubmit(data); // Pass the customer details to the parent component
      } else {
        alert(`Failed to fetch customer details: ${response.statusText}`);
      }
    } catch (error) {
      console.error('Error fetching customer details:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleNextPage = () => {
    window.location.href = '/BookingForm';
  };

  return (
    <Container fluid className="p-0" style={{ backgroundImage: `url("https://static.wixstatic.com/media/eb3040_c0eb112d6351421cb306fc807236823b~mv2.jpg/v1/fill/w_922,h_482,al_c,lg_1,q_85/eb3040_c0eb112d6351421cb306fc807236823b~mv2.jpg")`, backgroundSize: 'cover', minHeight: '100vh' }}>
      <Row className="justify-content-center">
        <Col md={8} lg={6}>
          <div className="card" style={{ width: '100%', margin: '50px auto', backgroundColor: 'rgba(0, 0, 0, 0.4)', color: 'rgba(32,23,18,255)', borderRadius: '15px', boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)' }}>
            <div className="card-body">
              <h2 className="mb-4" style={{ textAlign: 'center', textDecoration: 'underline' }}>Enter Customer's Email</h2>
              <Form onSubmit={handleSubmit}>
                <Form.Group controlId="email" style={{ marginBottom: '20px' }}>
                  <Form.Label>Email:</Form.Label>
                  <Form.Control type="email" placeholder="Enter email" value={email} onChange={(e) => setEmail(e.target.value)} required style={{ borderRadius: '8px' }} />
                </Form.Group>
                <div style={{ textAlign: 'center' }}>
                  <Button type="submit" style={{ backgroundColor: 'black', border: '1px solid rgba(32,23,18,255)', color: 'bisque', borderRadius: '8px', padding: '10px 20px' }} disabled={loading}>
                    {loading ? 'Loading...' : 'Submit'}
                  </Button>
                </div>
              </Form>
              {customerData && (
                <div>
                  <h3 className="mt-4" style={{ textAlign: 'center', textDecoration: 'underline' }}>Customer Details</h3>
                  <table className="table table-bordered" style={{ color: 'rgba(32,23,18,255)', margin: 'auto', marginBottom: '20px' }}>
                    <tbody>
                      <tr>
                        <td>Customer Id:</td>
                        <td>{customerData.customerId}</td>
                      </tr>
                      <tr>
                        <td>First Name:</td>
                        <td>{customerData.firstName}</td>
                      </tr>
                      <tr>
                        <td>Last Name:</td>
                        <td>{customerData.lastName}</td>
                      </tr>
                      <tr>
                        <td>Address Line 1:</td>
                        <td>{customerData.addressLine1}</td>
                      </tr>
                      <tr>
                        <td>Address Line 2:</td>
                        <td>{customerData.addressLine2}</td>
                      </tr>
                      <tr>
                        <td>Email:</td>
                        <td>{customerData.email}</td>
                      </tr>
                      <tr>
                        <td>City:</td>
                        <td>{customerData.city}</td>
                      </tr>
                      <tr>
                        <td>Pincode:</td>
                        <td>{customerData.pincode}</td>
                      </tr>
                      <tr>
                        <td>Phone Number:</td>
                        <td>{customerData.phoneNumber}</td>
                      </tr>
                      <tr>
                        <td>Mobile Number:</td>
                        <td>{customerData.mobileNumber}</td>
                      </tr>
                    </tbody>
                  </table>
                  <div style={{ textAlign: 'center' }}>
                    <Button className="btn btn-primary" onClick={handleNextPage} style={{ backgroundColor: 'black', border: '1px solid bisque', color: 'bisque', borderRadius: '8px', padding: '10px 20px' }}>
                      Continue
                    </Button>
                  </div>
                </div>
              )}
            </div>
          </div>
        </Col>
      </Row>
    </Container>
  );
};

export default BookingByStaff;

