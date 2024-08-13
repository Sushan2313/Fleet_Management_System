import React, { useState } from 'react';
import { Container, Row, Col, Form, Button, Table, Spinner } from 'react-bootstrap';

const CancelBookingByStaff = () => {
  const [emailId, setEmailId] = useState('');
  const [bookings, setBookings] = useState([]);
  const [loading, setLoading] = useState(false);
  const [deletingBookingId, setDeletingBookingId] = useState(null);

  const fetchBookings = async () => {
    try {
      setLoading(true);
      const response = await fetch(`http://localhost:8080/api/booking/email/${emailId}`);

      if (response.ok) {
        const data = await response.json();
        console.log('API Response:', data);
        setBookings(data);
      } else {
        console.error('Failed to fetch bookings:', response.statusText);
      }
    } catch (error) {
      console.error('Error fetching bookings:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteBooking = async (deletingBookingId) => {
    try {
      console.log(deletingBookingId);
      setDeletingBookingId(deletingBookingId); // Set the bookingId being deleted
      const response = await fetch(`http://localhost:8080/api/deletebooking/${deletingBookingId}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        console.log('Booking successfully canceled:', deletingBookingId);
        deleteAddons(deletingBookingId);
        fetchBookings();
      } else {
        console.error('Failed to cancel booking:', response.statusText);
      }
    } catch (error) {
      console.error('Error canceling booking:', error);
    } finally {
      setDeletingBookingId(null); // Reset the deletingBookingId
    }
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    fetchBookings();
  };

  const deleteAddons = (deletingBookingId) => {
    const url = `http://localhost:8080/bookingdetails/${deletingBookingId}`;

    fetch(url)
      .then(response => {
        if (response.ok) {
          return response.json();
        } else {
          throw new Error('Failed to fetch booking details. Status code: ' + response.status);
        }
      })
      .then(data => {
        console.log('Booking details:', data);
      })
      .catch(error => {
        console.error('Error:', error);
      });
  };

  return (
    <Container fluid className="p-0" style={{ backgroundImage: `url("https://cdni.iconscout.com/illustration/premium/thumb/car-dealer-explaining-sales-contract-to-a-couple-buying-a-car-6920989-5662120.png?f=webp")`, backgroundSize: 'cover', minHeight: '100vh' }}>
      <Container className="p-4" style={{ textAlign:'Center',background: 'rgba(0, 0, 0, 0)', borderRadius: '15px', color: 'black', maxWidth: '80%', margin: '0 auto', marginTop: '20px' }}>
        <Row>
          <Col>
            <div style={{ boxShadow: '0 0 10px rgba(0, 0, 0, 0.5)', padding: '20px', borderRadius: '10px', background: 'rgba(255, 255, 255, 0.1)' }}>
              <Form onSubmit={handleSubmit}>
                <Form.Group controlId="formEmail">
                  <Form.Label>Enter Customer's Email</Form.Label>
                  <Form.Control
                    type="email"
                    placeholder="Enter email"
                    value={emailId}
                    onChange={(e) => setEmailId(e.target.value)}
                    required
                    style={{ borderRadius: '8px' }}
                  />
                </Form.Group>
                <Button type="submit" style={{ marginTop: '10px', backgroundColor: 'black', border: '1px solid bisque', color: 'bisque', borderRadius: '8px' }} disabled={loading}>
                  Submit
                </Button>
              </Form>
              {loading && <Spinner animation="border" variant="light" style={{ marginTop: '10px' }} />}
            </div>
          </Col>
        </Row>
        {bookings.length > 0 && (
          <Row style={{ marginTop: '20px' }}>
            <Col>
              <h3>Bookings</h3>
              <Table striped bordered hover variant="dark">
                <thead>
                  <tr>
                    <th>Booking Id</th>
                    <th>First Name</th>
                    <th>Booking Date</th>
                    <th>Action</th>
                  </tr>
                </thead>
                <tbody>
                  {bookings.map((booking) => (
                    <tr key={booking.bookingId}>
                      <td>{booking.bookingId}</td>
                      <td>{booking.firstName}</td>
                      <td>{booking.bookingDate}</td>
                      <td>
                        <Button
                          variant="danger"
                          onClick={() => handleDeleteBooking(booking.bookingId)}
                          disabled={deletingBookingId === booking.bookingId}
                        >
                          {deletingBookingId === booking.bookingId ? 'Deleting...' : 'Delete'}
                        </Button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </Table>
            </Col>
          </Row>
        )}
      </Container>
    </Container>
  );
};

export default CancelBookingByStaff;

