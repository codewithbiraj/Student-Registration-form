import React, { useEffect, useState } from "react";
import axios from "axios";

const ViewDetails = () => {
  const [students, setStudents] = useState([]);
  const [selectedStudent, setSelectedStudent] = useState(null);
  const [editMode, setEditMode] = useState(false);

  /* ================= FETCH STUDENTS ================= */
  useEffect(() => {
    fetchStudents();
  }, []);

  const fetchStudents = async () => {
    try {
      const res = await axios.get("http://localhost:5135/api/Student");
      setStudents(res.data);
    } catch (err) {
      console.error(err);
    }
  };

  /* ================= HANDLE CHANGE (FIXED) ================= */
  const handleChange = (section, field, value) => {
    if (section) {
      setSelectedStudent((prev) => ({
        ...prev,
        [section]: {
          ...prev[section],
          [field]: value,
        },
      }));
    } else {
      setSelectedStudent((prev) => ({
        ...prev,
        [field]: value,
      }));
    }
  };

  /* ================= UPDATE ================= */
  const handleUpdate = async () => {
    try {
      console.log("Updating:", selectedStudent);

      await axios.put(
        `http://localhost:5135/api/Student/${selectedStudent.id}`,
        selectedStudent,
        { headers: { "Content-Type": "application/json" } }
      );

      alert("Student updated successfully");
      setEditMode(false);
      setSelectedStudent(null);
      fetchStudents();
    } catch (err) {
      console.error("Update failed:", err.response?.data || err.message);
      alert("Update failed. Check console.");
    }
  };

  /* ================= DELETE ================= */
  const handleDelete = async (id) => {
    if (!window.confirm("Delete this student?")) return;

    try {
      await axios.delete(`http://localhost:5135/api/Student/${id}`);
      fetchStudents();
    } catch (err) {
      console.error("Delete failed:", err.response?.data || err.message);
    }
  };

  /* ================= LIST VIEW ================= */
  if (!selectedStudent) {
    return (
      <div className="max-w-6xl mx-auto p-6">
        <h2 className="text-2xl font-bold mb-4">Student List</h2>

        <table className="w-full border">
          <thead>
            <tr className="bg-gray-200">
              <th className="border p-2">Name</th>
              <th className="border p-2">Email</th>
              <th className="border p-2">Actions</th>
            </tr>
          </thead>

          <tbody>
            {students.map((s) => (
              <tr key={s.id}>
                <td className="border p-2">
                  {s.firstName} {s.lastName}
                </td>
                <td className="border p-2">{s.email}</td>
                <td className="border p-2 flex gap-2">
                  <button
                    className="bg-blue-600 text-white px-3 py-1 rounded"
                    onClick={() => setSelectedStudent(s)}
                  >
                    View / Update
                  </button>

                  <button
                    className="bg-red-600 text-white px-3 py-1 rounded"
                    onClick={() => handleDelete(s.id)}
                  >
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }

  /* ================= DETAILS VIEW ================= */
  return (
    <div className="max-w-xl mx-auto p-6">
      <h2 className="text-xl font-bold mb-4">Student Details</h2>

      {/* BASIC */}
      {["firstName", "lastName", "dateOfBirth", "placeOfBirth", "nationality","citizenshipNumber","citizenshipIssueDate","citizenshipIssueDistrict","email","alternativeEmail","phoneNumber","secondaryPhoneNumber","emergencyContactNumber","gender","bloodGroup","maritalStatus","religion","ethnicity","disability"].map(
        (field) => (
          <div key={field} className="mb-3">
            <label className="font-semibold capitalize">{field}</label>

            {editMode ? (
              <input
                className="border p-2 w-full mt-1"
                value={selectedStudent[field] || ""}
                onChange={(e) =>
                  handleChange(null, field, e.target.value)
                }
              />
            ) : (
              <p className="mt-1">{selectedStudent[field]}</p>
            )}
          </div>
        )
      )}

      {/* ADDRESS (NESTED) */}
      <h3 className="font-bold mt-6 mb-2">Address</h3>

      {["province", "municipality", "tole","addressType"].map((field) => (
        <div key={field} className="mb-3">
          <label className="font-semibold capitalize">{field}</label>

          {editMode ? (
            <input
              className="border p-2 w-full mt-1"
              value={selectedStudent.address?.[field] || ""}
              onChange={(e) =>
                handleChange("address", field, e.target.value)
              }
            />
          ) : (
            <p className="mt-1">{selectedStudent.address?.[field]}</p>
          )}
        </div>
      ))}

      {/* Parent (NESTED) */}
      <h3 className="font-bold mt-6 mb-2">parentdetails</h3>

      {["fatherName", "fatherOccupation", "fatherPhoneNumber","motherName","motherOccupation","motherPhoneNumber","guardianName","guardianOccupation","guardianPhoneNumber"].map((field) => (
        <div key={field} className="mb-3">
          <label className="font-semibold capitalize">{field}</label>

          {editMode ? (
            <input
              className="border p-2 w-full mt-1"
              value={selectedStudent.parentdetails?.[field] || ""}
              onChange={(e) =>
                handleChange("parentdetails", field, e.target.value)
              }
            />
          ) : (
            <p className="mt-1">{selectedStudent.parentdetails?.[field]}</p>
          )}
        </div>
      ))}

      {/* Academic details (NESTED) */}
      <h3 className="font-bold mt-6 mb-2">academicdetails</h3>

      {["previousGrade", "yearOfCompletion", "percentage","programeType","subjectType"].map((field) => (
        <div key={field} className="mb-3">
          <label className="font-semibold capitalize">{field}</label>

          {editMode ? (
            <input
              className="border p-2 w-full mt-1"
              value={selectedStudent.academicdetails?.[field] || ""}
              onChange={(e) =>
                handleChange("academicdetails", field, e.target.value)
              }
            />
          ) : (
            <p className="mt-1">{selectedStudent.academicdetails?.[field]}</p>
          )}
        </div>
      ))}

      {/* financialdetails (NESTED) */}
      <h3 className="font-bold mt-6 mb-2">financialdetails</h3>

      {["scholarshipType", "feeCategory"].map((field) => (
        <div key={field} className="mb-3">
          <label className="font-semibold capitalize">{field}</label>

          {editMode ? (
            <input
              className="border p-2 w-full mt-1"
              value={selectedStudent.financialdetails?.[field] || ""}
              onChange={(e) =>
                handleChange("financialdetails", field, e.target.value)
              }
            />
          ) : (
            <p className="mt-1">{selectedStudent.financialdetails?.[field]}</p>
          )}
        </div>
      ))}

      {/* extraCurricular (NESTED) */}
      <h3 className="font-bold mt-6 mb-2">extraCurricular</h3>

      {["interest", "timeSlot", "transportationMethod"].map((field) => (
        <div key={field} className="mb-3">
          <label className="font-semibold capitalize">{field}</label>

          {editMode ? (
            <input
              className="border p-2 w-full mt-1"
              value={selectedStudent.extraCurricular?.[field] || ""}
              onChange={(e) =>
                handleChange("extraCurricular", field, e.target.value)
              }
            />
          ) : (
            <p className="mt-1">{selectedStudent.extraCurricular?.[field]}</p>
          )}
        </div>
      ))}

      {/* BUTTONS */}
      <div className="flex gap-3 mt-6">
        {!editMode ? (
          <button
            className="bg-blue-600 text-white px-6 py-2 rounded"
            onClick={() => setEditMode(true)}
          >
            Edit
          </button>
        ) : (
          <>
            <button
              className="bg-green-600 text-white px-6 py-2 rounded"
              onClick={handleUpdate}
            >
              Save
            </button>

            <button
              className="bg-gray-500 text-white px-6 py-2 rounded"
              onClick={() => {
                setEditMode(false);
                setSelectedStudent(null);
              }}
            >
              Cancel
            </button>
          </>
        )}

        <button
          className="bg-red-600 text-white px-6 py-2 rounded"
          onClick={() => setSelectedStudent(null)}
        >
          Back
        </button>
      </div>
    </div>
  );
};

export default ViewDetails;
