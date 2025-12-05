CREATE DATABASE IF NOT EXISTS 'db_project';

-- Create appointments table
CREATE TABLE appointments (
    appointment_id NUMBER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    patient_name VARCHAR2 (100) NOT NULL,
    doctor_name VARCHAR2 (100) NOT NULL,
    appointment_date DATE NOT NULL,
    appointment_time VARCHAR2 (10) NOT NULL,
    notes VARCHAR2 (500),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create index for faster searches
CREATE INDEX idx_appointment_date ON appointments (appointment_date);

-- Insert some sample data
INSERT INTO
    appointments (
        patient_name,
        doctor_name,
        appointment_date,
        appointment_time,
        notes
    )
VALUES (
        'John Smith',
        'Dr. Sarah Johnson',
        TO_DATE('2024-12-10', 'YYYY-MM-DD'),
        '09:00 AM',
        'Regular checkup'
    );

INSERT INTO
    appointments (
        patient_name,
        doctor_name,
        appointment_date,
        appointment_time,
        notes
    )
VALUES (
        'Mary Wilson',
        'Dr. Michael Brown',
        TO_DATE('2024-12-10', 'YYYY-MM-DD'),
        '10:30 AM',
        'Follow-up appointment'
    );

INSERT INTO
    appointments (
        patient_name,
        doctor_name,
        appointment_date,
        appointment_time,
        notes
    )
VALUES (
        'Robert Davis',
        'Dr. Sarah Johnson',
        TO_DATE('2024-12-11', 'YYYY-MM-DD'),
        '02:00 PM',
        'Initial consultation'
    );

COMMIT;