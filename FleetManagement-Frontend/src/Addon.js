import React, { useState, useEffect } from 'react';
import { Card, Form, Button } from 'react-bootstrap';

const AddonList = () => {
    const [addons, setAddons] = useState([]);
    const [selectedAddons, setSelectedAddons] = useState([]);

    useEffect(() => {
        fetchAddons();
    }, []);

    const fetchAddons = async () => {
        try {
            const response = await fetch('http://localhost:8080/add_on');
            if (response.ok) {
                const data = await response.json();
                sessionStorage.setItem('addons', JSON.stringify(data));
                setAddons(data);
            } else {
                console.error('Failed to fetch addons');
            }
        } catch (error) {
            console.error('Error fetching addons:', error);
        }
    };

    const handleSelectAddon = (addonId) => {
        if (selectedAddons.includes(addonId)) {
            setSelectedAddons(selectedAddons.filter(id => id !== addonId));
        } else {
            setSelectedAddons([...selectedAddons, addonId]);
        }
    };

    useEffect(() => {
        sessionStorage.setItem('selectedAddons', JSON.stringify(selectedAddons));
    }, [selectedAddons]);

    const handleContinue = () => {
        console.log('Selected addons:', selectedAddons);
        window.location.href = '/StaffBookingForm';
    };

    return (
        <>
            <h1 className="mb-4 text-center">Available Add-ons</h1>
            <div className="d-flex flex-wrap justify-content-center align-items-center">
                {addons.map((addon) => (
                    <Card
                        key={addon.addonId}
                        className="addon-card shadow-sm"
                        style={{
                            width: '20rem',
                            margin: '15px',
                            borderRadius: '10px',
                            overflow: 'hidden',
                            transition: 'transform 0.2s, box-shadow 0.2s',
                        }}
                    >
                        <Card.Body>
                            <Card.Title className="text-primary">{addon.addonName}</Card.Title>
                            <Card.Text className="mb-2 text-muted">
                                Rate: <span className="text-dark">&#8377;{addon.addonDailyRate.toFixed(2)}</span> per day
                            </Card.Text>
                            <Card.Text className="mb-4 text-muted">
                                Valid Until: <span className="text-dark">{new Date(addon.rateValidUntil).toLocaleDateString()}</span>
                            </Card.Text>
                            <Form.Check
                                type="checkbox"
                                id={`addon-${addon.addonId}`}
                                label="Select"
                                checked={selectedAddons.includes(addon.addonId)}
                                onChange={() => handleSelectAddon(addon.addonId)}
                                className="addon-checkbox"
                            />
                        </Card.Body>
                    </Card>
                ))}
            </div>
            <div className="text-center mt-4">
                <Button
                    variant="primary"
                    onClick={handleContinue}
                    className="continue-button"
                    style={{
                        padding: '10px 20px',
                        fontSize: '16px',
                        borderRadius: '5px',
                        boxShadow: '0 4px 8px rgba(0, 0, 0, 0.1)',
                    }}
                >
                    Continue
                </Button>
            </div>
        </>
    );
};

export default AddonList;