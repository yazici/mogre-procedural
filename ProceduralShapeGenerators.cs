

/*
-----------------------------------------------------------------------------
This source file is part of mogre-procedural
For the latest info, see http://code.google.com/p/mogre-procedural/
my blog:http://hi.baidu.com/rainssoft
this is overwrite  ogre-procedural c++ project using c#, look  ogre-procedural c++ source http://code.google.com/p/ogre-procedural/
   
Copyright (c) 2013-2020 rains soft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
-----------------------------------------------------------------------------
*/
//#ifndef PROCEDURAL_SHAPE_GENERATORS_INCLUDED
#define PROCEDURAL_SHAPE_GENERATORS_INCLUDED
//use new std wrapper...ok


namespace Mogre_Procedural
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Mogre;
    using Math = Mogre.Math;
    using Mogre_Procedural.std;
    using ControlPoint = Mogre_Procedural.CubicHermiteSplineControlPoint<Mogre.Vector2>;
    using ControlPoint2 = Mogre_Procedural.KochanekBartelsSplineControlPoint<Mogre.Vector2>;
    //*
    // * \addtogroup shapegrp
    // * @{
    // 
    //-----------------------------------------------------------------------
    //*
    // * Produces a shape from Cubic Hermite control points
    // * \image html spline_cubichermite.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport CubicHermiteSpline2 : public BaseSpline2<CubicHermiteSpline2>
    public class CubicHermiteSpline2 : BaseSpline2<CubicHermiteSpline2>
    {
        //#define ControlPoint_AlternateDefinition1
        private std_vector<ControlPoint> mPoints = new std_vector<CubicHermiteSplineControlPoint<Vector2>>();
        /// Adds a control point
        public CubicHermiteSpline2 addPoint(Vector2 p, Vector2 before, Vector2 after) {
            mPoints.push_back(new CubicHermiteSplineControlPoint<Vector2>(p, before, after));
            return this;
        }
        /// Adds a control point
        public CubicHermiteSpline2 addPoint(Vector2 p, Vector2 tangent) {
            mPoints.push_back(new CubicHermiteSplineControlPoint<Vector2>(p, tangent, tangent));
            return this;
        }
        /// Adds a control point
        public CubicHermiteSpline2 addPoint(Vector2 p) {
            return addPoint(p, CubicHermiteSplineAutoTangentMode.AT_CATMULL);
        }
        //
        //ORIGINAL LINE: inline CubicHermiteSpline2& addPoint(const Ogre::Vector2& p, CubicHermiteSplineAutoTangentMode autoTangentMode = AT_CATMULL)
        public CubicHermiteSpline2 addPoint(Vector2 p, CubicHermiteSplineAutoTangentMode autoTangentMode) {
            CubicHermiteSplineControlPoint<Vector2> cp = new CubicHermiteSplineControlPoint<Vector2>();
            //
            //ORIGINAL LINE: cp.position = p;
            cp.position = (p);
            cp.autoTangentBefore = autoTangentMode;
            cp.autoTangentAfter = autoTangentMode;
            mPoints.push_back(cp);
            return this;
        }

        /// Adds a control point
        public CubicHermiteSpline2 addPoint(float x, float y) {
            return addPoint(x, y, CubicHermiteSplineAutoTangentMode.AT_CATMULL);
        }
        //
        //ORIGINAL LINE: inline CubicHermiteSpline2& addPoint(Ogre::float x, Ogre::float y, CubicHermiteSplineAutoTangentMode autoTangentMode = AT_CATMULL)
        public CubicHermiteSpline2 addPoint(float x, float y, CubicHermiteSplineAutoTangentMode autoTangentMode) {
            CubicHermiteSplineControlPoint<Vector2> cp = new CubicHermiteSplineControlPoint<Vector2>();
            cp.position = new Vector2(x, y);
            cp.autoTangentBefore = autoTangentMode;
            cp.autoTangentAfter = autoTangentMode;
            mPoints.push_back(cp);
            return this;
        }

        /// Safely gets a control point
        //
        //ORIGINAL LINE: inline const CubicHermiteSplineControlPoint<Ogre::Vector2>& safeGetPoint(uint i) const
        public CubicHermiteSplineControlPoint<Vector2> safeGetPoint(int i) {
            if (mClosed)
                return mPoints[Utils.modulo((int)i, mPoints.size())];
            return mPoints[Utils.cap((int)i, 0, mPoints.size() - 1)];
        }

        //    *
        //	 * Builds a shape from control points
        //	 
        //-----------------------------------------------------------------------

        //Shape CubicHermiteSpline2::realizeShape()
        public Shape realizeShape() {
            Shape shape = new Shape();

            int numPoints = mClosed ? mPoints.size() : (mPoints.size() - 1);
            //Precompute tangents
            for (int i = 0; i < mPoints.size(); ++i) {
                CubicHermiteSplineControlPoint<Vector2> mp = mPoints[i];
                GlobalMembers.computeTangents(ref mp, safeGetPoint((i - 1)).position, safeGetPoint(i + 1).position);
            }
            for (int i = 0; i < numPoints; ++i) {
                ControlPoint pointBefore = mPoints[i];
                ControlPoint pointAfter = safeGetPoint(i + 1);
                std_vector<Vector2> shape_getPointsReference = shape.getPointsReference();
                GlobalMembers.computeCubicHermitePoints(pointBefore, pointAfter, (uint)mNumSeg, ref  shape_getPointsReference);

                if (i == mPoints.size() - 2 && !mClosed) {
                    shape.addPoint(pointAfter.position);
                }
            }
            if (mClosed)
                shape.close();
            shape.setOutSide(mOutSide);

            return shape;
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a shape from a Catmull-Rom Spline.
    // * A catmull-rom smoothly interpolates position between control points
    // * \image html spline_catmull.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport CatmullRomSpline2 : public BaseSpline2<CatmullRomSpline2>
    public class CatmullRomSpline2 : BaseSpline2<CatmullRomSpline2>
    {
        private std_vector<Vector2> mPoints = new std_vector<Vector2>();
        /// Adds a control point
        public CatmullRomSpline2 addPoint(Vector2 pt) {
            mPoints.push_back(pt);
            return this;
        }

        /// Adds a control point
        public CatmullRomSpline2 addPoint(float x, float y) {
            mPoints.push_back(new Vector2(x, y));
            return this;
        }

        /// Safely gets a control point
        //
        //ORIGINAL LINE: inline const Ogre::Vector2& safeGetPoint(uint i) const
        public Vector2 safeGetPoint(uint i) {
            if (mClosed)
                return mPoints[Utils.modulo((int)i, mPoints.Count)];
            return mPoints[Utils.cap((int)i, 0, mPoints.Count - 1)];
        }

        //    *
        //	 * Build a shape from bezier control points
        //	 
        //-----------------------------------------------------------------------
        public Shape realizeShape() {
            Shape shape = new Shape();

            int numPoints = mClosed ? mPoints.Count : (mPoints.Count - 1);
            for (uint i = 0; i < numPoints; ++i) {
                Vector2 P1 = safeGetPoint(i - 1);
                Vector2 P2 = safeGetPoint(i);
                Vector2 P3 = safeGetPoint(i + 1);
                Vector2 P4 = safeGetPoint(i + 2);
                std_vector<Vector2> shape_getPointsReference = shape.getPointsReference();
                GlobalMembers.computeCatmullRomPoints(P1, P2, P3, P4, mNumSeg, ref shape_getPointsReference);

                if (i == mPoints.Count - 2 && !mClosed) {
                    shape.addPoint(P3);
                }

            }
            if (mClosed)
                shape.close();
            shape.setOutSide(mOutSide);

            return shape;
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a shape from a Kochanek Bartels spline.
    // * \image html spline_kochanekbartels.png
    // * More details here : http://en.wikipedia.org/wiki/Kochanek%E2%80%93Bartels_spline
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport KochanekBartelsSpline2 : public BaseSpline2<KochanekBartelsSpline2>
    public class KochanekBartelsSpline2 : BaseSpline2<KochanekBartelsSpline2>
    {
        //#define ControlPoint_AlternateDefinition2
        private std_vector<ControlPoint2> mPoints = new std_vector<KochanekBartelsSplineControlPoint<Vector2>>();

        /// Adds a control point
        public KochanekBartelsSpline2 addPoint(float x, float y) {
            mPoints.push_back(new KochanekBartelsSplineControlPoint<Vector2>(new Vector2(x, y)));
            return this;
        }

        /// Adds a control point
        public KochanekBartelsSpline2 addPoint(Vector2 p) {
            mPoints.push_back(new KochanekBartelsSplineControlPoint<Vector2>(p));
            return this;
        }

        /// Safely gets a control point
        //
        //ORIGINAL LINE: inline const KochanekBartelsSplineControlPoint<Ogre::Vector2>& safeGetPoint(uint i) const
        public KochanekBartelsSplineControlPoint<Vector2> safeGetPoint(uint i) {
            if (mClosed)
                return mPoints[Utils.modulo((int)i, mPoints.Count)];
            return mPoints[Utils.cap((int)i, 0, mPoints.Count - 1)];
        }

        //    *
        //	 * Adds a control point to the spline
        //	 * @param p Point position
        //	 * @param t Tension    +1 = Tight            -1 = Round
        //	 * @param b Bias       +1 = Post-shoot       -1 = Pre-shoot
        //	 * @param c Continuity +1 = Inverted Corners -1 = Box Corners
        //	 
        public KochanekBartelsSpline2 addPoint(Vector2 p, float t, float b, float c) {
            mPoints.push_back(new KochanekBartelsSplineControlPoint<Vector2>(p, t, b, c));
            return this;
        }

        //    *
        //	 * Builds a shape from control points
        //	 
        //-----------------------------------------------------------------------
        //Shape KochanekBartelsSpline2::realizeShape()
        public Shape realizeShape() {
            Shape shape = new Shape();

            int numPoints = mClosed ? mPoints.size() : (mPoints.size() - 1);
            for (uint i = 0; i < numPoints; ++i) {
                ControlPoint2 P1 = safeGetPoint(i - 1);
                ControlPoint2 P2 = safeGetPoint(i);
                ControlPoint2 P3 = safeGetPoint(i + 1);
                ControlPoint2 P4 = safeGetPoint(i + 2);
                std_vector<Vector2> shape_getPointsReference = shape.getPointsReference();
                GlobalMembers.computeKochanekBartelsPoints(P1, P2, P3, P4, mNumSeg, ref shape_getPointsReference);

                if (i == mPoints.size() - 2 && !mClosed) {
                    shape.addPoint(P3.position);
                }
            }
            if (mClosed)
                shape.close();
            shape.setOutSide(mOutSide);
            return shape;
        }

    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a rectangular shape
    // * \image html shape_rectangle.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport RectangleShape
    public class RectangleShape
    {
        private float mWidth = 0f;
        private float mHeight = 0f;

        /// Default constructor
        public RectangleShape() {
            mWidth = 1.0f;
            mHeight = 1.0f;
        }

        /// Sets width
        /// \exception Ogre::InvalidParametersException Width must be larger than 0!
        public RectangleShape setWidth(float width) {
            if (width <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "Width must be larger than 0!", "Procedural::RectangleShape::setWidth(Ogre::Real)");
            ;
            mWidth = width;
            return this;
        }

        private void OGRE_EXCEPT(string p, string p_2, string p_3) {
            throw new Exception(p + "_" + p_2 + "_" + p_3);
        }

        /// Sets height
        /// \exception Ogre::InvalidParametersException Height must be larger than 0!
        public RectangleShape setHeight(float height) {
            if (height <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "Height must be larger than 0!", "Procedural::RectangleShape::setHeight(Ogre::Real)");
            ;
            mHeight = height;
            return this;
        }

        /// Builds the shape
        public Shape realizeShape() {
            Shape s = new Shape();
            s.addPoint(-0.5f * mWidth, -0.5f * mHeight)
                .addPoint(0.5f * mWidth, -0.5f * mHeight)
                .addPoint(0.5f * mWidth, 0.5f * mHeight)
                .addPoint(-0.5f * mWidth, 0.5f * mHeight)
                .close();
            return s;
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a circular shape
    // * \image html shape_circle.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport CircleShape
    public class CircleShape
    {
        private float mRadius = 0f;
        private uint mNumSeg;

        /// Default constructor
        public CircleShape() {
            mRadius = 1.0f;
            mNumSeg = 8;
        }

        /// Sets radius
        /// \exception Ogre::InvalidParametersException Radius must be larger than 0!
        public CircleShape setRadius(float radius) {
            if (radius <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "Radius must be larger than 0!", "Procedural::CircleShape::setRadius(Ogre::Real)");
            ;
            mRadius = radius;
            return this;
        }
        private void OGRE_EXCEPT(string p, string p_2, string p_3) {
            throw new Exception(p + "_" + p_2 + "_" + p_3);
        }
        /// Sets number of segments
        /// \exception Ogre::InvalidParametersException Minimum of numSeg is 1
        public CircleShape setNumSeg(uint numSeg) {
            if (numSeg == 0)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "There must be more than 0 segments", "Procedural::CircleShape::setNumSeg(unsigned int)");
            ;
            mNumSeg = numSeg;
            return this;
        }

        /// Builds the shape
        public Shape realizeShape() {
            Shape s = new Shape();
            float deltaAngle = Math.TWO_PI / (float)mNumSeg;
            for (uint i = 0; i < mNumSeg; ++i) {
                s.addPoint(mRadius * cosf(i * deltaAngle), mRadius * sinf(i * deltaAngle));
            }
            s.close();
            return s;
        }


        //---add
        private float sinf(float p) {
            return Math.Sin(p);
        }

        private float cosf(float p) {
            return Math.Cos(p);
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a ellipse shape
    // * \image html shape_ellipse.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport EllipseShape
    public class EllipseShape
    {
        private float mRadiusX = 0f;
        private float mRadiusY = 0f;
        private uint mNumSeg;

        /// Default constructor
        public EllipseShape() {
            mRadiusX = 1.0f;
            mRadiusY = 1.0f;
            mNumSeg = 8;
        }

        /// Sets radius in x direction
        /// \exception Ogre::InvalidParametersException Radius must be larger than 0!
        public EllipseShape setRadiusX(float radius) {
            if (radius <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "Radius must be larger than 0!", "Procedural::EllipseShape::setRadiusX(Ogre::Real)");
            ;
            mRadiusX = radius;
            return this;
        }
        private void OGRE_EXCEPT(string p, string p_2, string p_3) {
            throw new Exception(p + "_" + p_2 + "_" + p_3);
        }
        /// Sets radius in y direction
        /// \exception Ogre::InvalidParametersException Radius must be larger than 0!
        public EllipseShape setRadiusY(float radius) {
            if (radius <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "Radius must be larger than 0!", "Procedural::EllipseShape::setRadiusY(Ogre::Real)");
            ;
            mRadiusY = radius;
            return this;
        }

        /// Sets number of segments
        /// \exception Ogre::InvalidParametersException Minimum of numSeg is 1
        public EllipseShape setNumSeg(uint numSeg) {
            if (numSeg == 0)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "There must be more than 0 segments", "Procedural::EllipseShape::setNumSeg(unsigned int)");
            ;
            mNumSeg = numSeg;
            return this;
        }

        /// Builds the shape
        public Shape realizeShape() {
            Shape s = new Shape();
            float deltaAngle = Math.TWO_PI / (float)mNumSeg;
            for (uint i = 0; i < mNumSeg; ++i) {
                s.addPoint(mRadiusX * cosf(i * deltaAngle), mRadiusY * sinf(i * deltaAngle));
            }
            s.close();
            return s;
        }


        //----add
        private float sinf(float p) {
            return Math.Sin(p);
        }

        private float cosf(float p) {
            return Math.Cos(p);
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a triangele shape
    // * \image html shape_triangle.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport TriangleShape
    public class TriangleShape
    {
        private float mLengthA = 0f;
        private float mLengthB = 0f;
        private float mLengthC = 0f;

        /// Default constructor
        public TriangleShape() {
            mLengthA = 1.0f;
            mLengthB = 1.0f;
            mLengthC = 1.0f;
        }

        /// Creates an equilateral triangle
        /// \exception Ogre::InvalidStateException Length of triangle edges must be longer than 0!
        public TriangleShape setLength(float length) {
            if (length <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge must be longer than 0!", "Procedural::TriangleShape::setLengthA(Ogre::Real)");
            ;
            mLengthA = length;
            mLengthB = length;
            mLengthC = length;
            return this;
        }
        private void OGRE_EXCEPT(string p, string p_2, string p_3) {
            throw new Exception(p + "_" + p_2 + "_" + p_3);
        }
        /// Sets length of edge A
        /// \exception Ogre::InvalidStateException Length of triangle edge must be longer than 0!
        /// \exception Ogre::InvalidStateException Length of triangle edge A must be shorter or equal than B+C!
        public TriangleShape setLengthA(float length) {
            if (length <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge must be longer than 0!", "Procedural::TriangleShape::setLengthA(Ogre::Real)");
            if (length > (mLengthB + mLengthC))
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge A must be shorter or equal than B+C!", "Procedural::TriangleShape::setLengthA(Ogre::Real)");
            mLengthA = length;
            return this;
        }

        /// Sets length of edge B
        /// \exception Ogre::InvalidStateException Length of triangle edge must be longer than 0!
        /// \exception Ogre::InvalidStateException Length of triangle edge A must be shorter or equal than B+C!
        public TriangleShape setLengthB(float length) {
            if (length <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge must be longer than 0!", "Procedural::TriangleShape::setLengthB(Ogre::Real)");
            if (mLengthA > (length + mLengthC))
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge A must be shorter or equal than B+C!", "Procedural::TriangleShape::setLengthB(Ogre::Real)");
            mLengthB = length;

            return this;
        }

        /// Sets length of edge C
        /// \exception Ogre::InvalidStateException Length of triangle edge must be longer than 0!
        /// \exception Ogre::InvalidStateException Length of triangle edge A must be shorter or equal than B+C!
        public TriangleShape setLengthC(float length) {
            if (length <= 0.0f)
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge must be longer than 0!", "Procedural::TriangleShape::setLengthC(Ogre::Real)");
            if (mLengthA > (mLengthB + length))
                OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "Length of triangle edge A must be shorter or equal than B+C!", "Procedural::TriangleShape::setLengthC(Ogre::Real)");
            mLengthC = length;
            return this;
        }

        /// Builds the shape
        public Shape realizeShape() {
            Radian alpha = Math.ACos((mLengthB * mLengthB + mLengthC * mLengthC - mLengthA * mLengthA) / (2 * mLengthB * mLengthC));

            Shape s = new Shape();
            s.addPoint(0.0f, 0.0f);
            s.addPoint(Math.Cos(alpha) * mLengthB, Math.Sin(alpha) * mLengthB);
            s.addPoint(mLengthC, 0.0f);
            s.close();
            s.translate((Math.Cos(alpha) * mLengthB + mLengthC) / -3.0f, mLengthB / -3.0f);

            return s;
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Produces a shape from Cubic Hermite control points
    // * \image html spline_roundedcorner.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport RoundedCornerSpline2 : public BaseSpline2<RoundedCornerSpline2>
    public class RoundedCornerSpline2 : BaseSpline2<RoundedCornerSpline2>
    {
        private float mRadius = 0f;

        private std_vector<Vector2> mPoints = new std_vector<Vector2>();

        public RoundedCornerSpline2() {
            mRadius = .1f;
        }

        /// Sets the radius of the corners
        public RoundedCornerSpline2 setRadius(float radius) {
            mRadius = radius;
            return this;
        }

        /// Adds a control point
        public RoundedCornerSpline2 addPoint(Vector2 p) {
            mPoints.push_back(p);
            return this;
        }

        /// Adds a control point
        public RoundedCornerSpline2 addPoint(float x, float y) {
            mPoints.push_back(new Vector2(x, y));
            return this;
        }

        /// Safely gets a control point
        //
        //ORIGINAL LINE: inline const Ogre::Vector2& safeGetPoint(uint i) const
        public Vector2 safeGetPoint(uint i) {
            if (mClosed)
                return mPoints[Utils.modulo((int)i, mPoints.Count)];
            return mPoints[Utils.cap((int)i, 0, mPoints.Count - 1)];
        }

        //    *
        //	 * Builds a shape from control points
        //	 * \exception Ogre::InvalidStateException The path contains no points
        //	 
        //-----------------------------------------------------------------------
        public Shape realizeShape() {
            if (mPoints.empty())
              OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "The shape contains no points", "Procedural::RoundedCornerSpline2::realizePath()");
            ;

            Shape shape = new Shape();
            int numPoints = mClosed ? mPoints.Count : (mPoints.Count - 2);
            if (!mClosed)
                shape.addPoint(mPoints[0]);

            for (uint i = 0; i < numPoints; ++i) {
                Vector2 p0 = safeGetPoint(i);
                Vector2 p1 = safeGetPoint(i + 1);
                Vector2 p2 = safeGetPoint(i + 2);

                Vector2 vBegin = p1 - p0;
                Vector2 vEnd = p2 - p1;

                // We're capping the radius if it's too big compared to segment length
                float radius = mRadius;
                float smallestSegLength = System.Math.Min(vBegin.Length, vEnd.Length);
                if (smallestSegLength < 2 * mRadius)
                    radius = smallestSegLength / 2.0f;

                Vector2 pBegin = p1 - vBegin.NormalisedCopy * radius;
                Vector2 pEnd = p1 + vEnd.NormalisedCopy * radius;
                Line2D line1 = new Line2D(pBegin, vBegin.Perpendicular);
                Line2D line2 = new Line2D(pEnd, vEnd.Perpendicular);
                Vector2 center = new Vector2();
                line1.findIntersect(line2, ref center);
                Vector2 vradBegin = pBegin - center;
                Vector2 vradEnd = pEnd - center;
                Radian angleTotal = Utils.angleBetween(vradBegin, vradEnd);
                if (vradBegin.CrossProduct(vradEnd) < 0f)
                    angleTotal = -angleTotal;

                for (uint j = 0; j <= mNumSeg; j++) {
                    Vector2 deltaVector = Utils.rotateVector2(vradBegin, (float)j * angleTotal / (float)mNumSeg);
                    shape.addPoint(center + deltaVector);
                }
            }

            if (!mClosed)
                shape.addPoint(mPoints[mPoints.size() - 1]);

            if (mClosed)
                shape.close();
            shape.setOutSide(mOutSide);

            return shape;
        }
    }

    //-----------------------------------------------------------------------
    //*
    // * Builds a shape from a Bezier-Curve.
    // * \image html spline_beziercurve.png
    // 
    //C++ TO C# CONVERTER WARNING: The original type declaration contained unconverted modifiers:
    //ORIGINAL LINE: class _ProceduralExport BezierCurve2 : public BaseSpline2<BezierCurve2>
    public class BezierCurve2 : BaseSpline2<BezierCurve2>
    {
        private std_vector<Vector2> mPoints = new std_vector<Vector2>();
        private uint mNumSeg;

        /// Default constructor
        public BezierCurve2() {
            mNumSeg = 8;
        }

        /// Sets number of segments per two control points
        /// \exception Ogre::InvalidParametersException Minimum of numSeg is 1
        public BezierCurve2 setNumSeg(uint numSeg) {
            if (numSeg == 0)
               OGRE_EXCEPT("Ogre::Exception::ERR_INVALIDPARAMS", "There must be more than 0 segments", "Procedural::BezierCurve2::setNumSeg(unsigned int)");
            ;
            mNumSeg = numSeg;
            return this;
        }

        /// Adds a control point
        public BezierCurve2 addPoint(Vector2 pt) {
            mPoints.push_back(pt);
            return this;
        }

        /// Adds a control point
        public BezierCurve2 addPoint(float x, float y) {
            mPoints.push_back(new Vector2(x, y));
            return this;
        }

        /// Safely gets a control point
        //
        //ORIGINAL LINE: inline const Ogre::Vector2& safeGetPoint(uint i) const
        public Vector2 safeGetPoint(uint i) {
            if (mClosed)
                return mPoints[Utils.modulo((int)i, mPoints.Count)];
            return mPoints[Utils.cap((int)i, 0, mPoints.Count - 1)];
        }

        //    *
        //	 * Build a shape from bezier control points
        //	 * @exception Ogre::InvalidStateException The curve must at least contain 2 points
        //	 

        //-----------------------------------------------------------------------
        public Shape realizeShape() {
            if (mPoints.size() < 2)
               OGRE_EXCEPT("Ogre::Exception::ERR_INVALID_STATE", "The curve must at least contain 2 points", "Procedural::BezierCurve2::realizePath()");
            ;

            uint[] coef = new uint[mPoints.size()];
            if (mPoints.size() == 2) {
                coef[0] = 1;
                coef[1] = 1;
            }
            else if (mPoints.size() == 3) {
                coef[0] = 1;
                coef[1] = 2;
                coef[2] = 1;
            }
            else if (mPoints.size() == 4) {
                coef[0] = 1;
                coef[1] = 3;
                coef[2] = 3;
                coef[3] = 1;
            }
            else {
                for (uint i = 0; i < mPoints.size(); i++)
                    coef[i] = Utils.binom((uint)mPoints.size() - 1, i);
            }

            uint div = ((uint)mPoints.size() - 1) * mNumSeg + 1;
            float dt = 1.0f / (float)div;

            Shape shape = new Shape();
            float t = 0.0f;
            while (t < 1.0f) {
                float x = 0.0f;
                float y = 0.0f;
                for (int i = 0; i < (int)mPoints.size(); i++) {
                    float fac = (float)(coef[i] * System.Math.Pow(t, i) * System.Math.Pow(1.0f - t, (int)mPoints.size() - 1 - i));
                    x += fac * mPoints[i].x;
                    y += fac * mPoints[i].y;
                }
                shape.addPoint(x, y);
                t += dt;
            }
            //	delete coef;
            coef = null;

            return shape;
        }
    }
    //* @} 
}

